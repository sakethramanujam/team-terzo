using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public GameObject Blur_Bg;

	// Use this for initialization
	void Start () {
        Blur_Bg.SetActive(false);
	}

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void PanelOn(GameObject Panel)
    {
        Blur_Bg.SetActive(true);
        Panel.gameObject.SetActive(true);
    }

    public void ClosePanel(GameObject Panel)
    {
        Blur_Bg.SetActive(false);
        Panel.gameObject.SetActive(false);
    }

    public void PlayButtonSound()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[0].Name);
    }

    public void retry()
    {
        Blur_Bg.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayerGoals");
    }

    public void Pause()
    {
        Time.timeScale = 0;
      
    }

    public void resume()
    {
      
        Time.timeScale = 1;
    }

    public void MuteAndUmute()
    {
        SoundManager.Instance.ToggleMute();

        if (SoundManager.Instance.IsMuted())
        {
            GameObject.Find("Mute").GetComponentInChildren<Text>().text = "UnMute";
        }
        else
        {
            GameObject.Find("Mute").GetComponentInChildren<Text>().text = "Mute";
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
