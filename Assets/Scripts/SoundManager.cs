using UnityEngine;
using System.Collections;
using System.Collections.Generic;



    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;


        [System.Serializable]
        public class Sound
        {
            public string Name;
            public AudioClip Clip;
            [HideInInspector]
            public int SimultaneousPlayCount = 0;
        }

        [Tooltip("Max number of simultaneous sounds allowed")]
        public int MaxSimultaneousSounds =5;
        Sound SoundBuff;

        [Tooltip("List of game sounds")]
        public List<Sound> GameSounds;

        private AudioSource AudioSource;
        private const string MUTE_KEY = "MutePreference";
        private const int MUTED = 1;
        private const int UN_MUTED = -1;
       
        void Awake()
        {
            if (Instance)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
         
            if(GetComponent<AudioSource>()!=null)
            AudioSource = GetComponent<AudioSource>();

            SetMute(IsMuted());

        }

        void Start()
        {
            // Get audio source component
           

        }

        /// <summary>
        /// Plays the given sound with option to progressively scale down volume of multiple copies of same sound playing at
        /// the same time to eliminate the issue that sound amplitude adds up and becomes too loud.
        /// </summary>
        /// <param name="sound">Sound.</param>
        /// <param name="autoScaleVolume">If set to <c>true</c> auto scale down volume of same sounds played together.</param>
        /// <param name="maxVolumeScale">Max volume scale before scaling down.</param>
        public void PlaySound(string soundName, bool autoScaleVolume = true, float maxVolumeScale = 1f)
        {
            SoundBuff = GameSounds.Find(s => s.Name == soundName);
            StartCoroutine(CRPlaySound(SoundBuff, autoScaleVolume, maxVolumeScale));
        }

        IEnumerator CRPlaySound(Sound sound, bool autoScaleVolume = true, float maxVolumeScale = 1f)
        {
            if (sound.SimultaneousPlayCount >= MaxSimultaneousSounds)
            {
                yield break;
            }

            sound.SimultaneousPlayCount++;

            float vol = maxVolumeScale;

            // Scale down volume of same sound played subsequently
            if (autoScaleVolume && sound.SimultaneousPlayCount > 0)
            {
                vol = vol / (float)(sound.SimultaneousPlayCount);
            }

            AudioSource.PlayOneShot(sound.Clip, vol);

            // Wait til the sound almost finishes playing then reduce play count
            float delay = sound.Clip.length * 0.7f;

            yield return new WaitForSeconds(delay);

            sound.SimultaneousPlayCount--;
        }

        /// <summary>
        /// Plays the given music.
        /// </summary>
        /// <param name="music">Music.</param>
        /// <param name="loop">If set to <c>true</c> loop.</param>
        public void PlayMusic(Sound music, bool loop = true)
        {
            AudioSource.clip = music.Clip;
            AudioSource.loop = loop;
            AudioSource.Play();
        }

        /// <summary>
        /// Pauses the music.
        /// </summary>
        public void PauseMusic()
        {
            AudioSource.Pause();
        }

        /// <summary>
        /// Resumes the music.
        /// </summary>
        public void ResumeMusic()
        {
            AudioSource.UnPause();
        }

        /// <summary>
        /// Stop music.
        /// </summary>
        public void Stop()
        {
            AudioSource.Stop();
        }

        /// <summary>
        /// Determines whether sound is muted.
        /// </summary>
        /// <returns><c>true</c> if sound is muted; otherwise, <c>false</c>.</returns>
        public bool IsMuted()
        {
            return (PlayerPrefs.GetInt(MUTE_KEY, UN_MUTED) == MUTED);
            
        }

        /// <summary>
        /// Toggles the mute status.
        /// </summary>
        public void ToggleMute()
        {
            // Toggle current mute status
            bool mute = !IsMuted();

            if (mute)
            {
                // Muted
                PlayerPrefs.SetInt(MUTE_KEY, MUTED);

               
            }
            else
            {
                // Un-muted
                PlayerPrefs.SetInt(MUTE_KEY, UN_MUTED);

                
            }

            SetMute(mute);
        }

        void SetMute(bool isMuted)
        {
            AudioSource.mute = isMuted;
        }
    }
