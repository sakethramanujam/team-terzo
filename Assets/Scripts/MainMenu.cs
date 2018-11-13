using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

   
        private void Awake()
        {
            //Set screen size for Standalone
#if UNITY_STANDALONE
            Screen.SetResolution(564,960, false);
            Screen.fullScreen = false;
#endif
        }

    public Button togglemute;
    public Sprite mute,unmute;

    private void Start()
    {
        //SoundManager.Instance.PlayMusic(SoundManager.Instance.GameSounds[0]);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayerGoals");
    }

    public void PanelOn(GameObject Panel)
    {
        Panel.gameObject.SetActive(true);
    }

    public void ClosePanel(GameObject Panel)
    {
        Panel.gameObject.SetActive(false);
    }

    public void PlayButtonSound()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[0].Name);
    }

    public void MuteAndUmute()
    {
        SoundManager.Instance.ToggleMute();

        if (SoundManager.Instance.IsMuted())
        {
            togglemute.image.overrideSprite = unmute;
        }
        else
        {
            togglemute.image.overrideSprite = mute;
        }
    }
}
