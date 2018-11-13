using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Splash : MonoBehaviour
{
    public float Logotime = 2f;
    public GameObject SplashScreen;

    public void Loading()
    {
       
    }

    // Use this for initialization
    void Start()
    {
       // SoundManager.Instance.PlayMusic(SoundManager.Instance.GameSounds[0]);
        StartCoroutine(ShowLogo());
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ShowLogo()
    {
        yield return new WaitForSeconds(Logotime);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

}
