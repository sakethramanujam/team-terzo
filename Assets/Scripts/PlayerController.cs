﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered


      
    public float MoveDistance = 150;

    private int playerPosition = 1;

    public int IncomeEquality;
    public int GenderEquality;
    public int EducationEquality;
    public int ReligionEquality;

    public Slider IncomeSlider;
    public Slider GenderSlider;
    public Slider EducationSlider;
    public Slider ReligionSlider;
    public GameObject GameOverPanel;

    public Obstaclepool obstaclepool;



    public Text MoneyThreshold;
    public Text GenderThreshold;
    public Text ReligionThreshold;
    public Text EducationThreshold;

    public Text Money;
    public Text Gender;
    public Text Religion;
    public Text Education;

    public Text YourScore, HighScore;
    public GameObject Blur_Bg;

    void Start()
    {
       
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.GameSounds[2]);
        Blur_Bg.SetActive(false);
        GameOverPanel.SetActive(false);
        IncomeEquality = (int)Random.Range(20, PlayerGoals.Instance.MaxIncomeEquality/2);
        GenderEquality = (int)Random.Range(20, PlayerGoals.Instance.MaxGenderEquality/2);
        ReligionEquality = (int)Random.Range(70, PlayerGoals.Instance.MaxReligionEquality/2);
        EducationEquality = (int)Random.Range(70, PlayerGoals.Instance.MaxEducationEquality/2);
        MoneyThreshold.text=""+ PlayerGoals.Instance.MaxIncomeEquality;
        GenderThreshold.text = "" + PlayerGoals.Instance.MaxGenderEquality;
        ReligionThreshold.text = "" + PlayerGoals.Instance.MaxReligionEquality;
        EducationThreshold.text = "" + PlayerGoals.Instance.MaxEducationEquality;


        Money.text = "" + IncomeEquality;
        Gender.text = "" + GenderEquality;
        Religion.text = "" + ReligionEquality;
        Education.text = "" + EducationEquality;

        IncomeSlider.maxValue = 100;
        IncomeSlider.minValue = 0;
        IncomeSlider.value = IncomeEquality;

        GenderSlider.maxValue = 100;
        GenderSlider.minValue = 0;
        GenderSlider.value = GenderEquality;

        EducationSlider.maxValue = 100;
        EducationSlider.minValue = 0;
        EducationSlider.value = EducationEquality;

        ReligionSlider.maxValue = 100;
        ReligionSlider.minValue = 0;
        ReligionSlider.value = ReligionEquality;

        dragDistance = Screen.height * 10 / 100; //dragDistance is 15% height of the screen
    }






    private void Update()
    {

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance )
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            if (playerPosition < 2)
                            {
                                // move the player along the positive Z axis
                                transform.Translate(MoveDistance, 0, 0);
                                // increment the player position
                                playerPosition++;
                            }
                        }
                        else
                        {   //Left swipe
                            if (playerPosition > 0)
                            {
                                // move the player along the negative Z axis
                                transform.Translate(-MoveDistance, 0, 0);
                                // decrement the player position
                                playerPosition--;
                            }
                        }
                    }
                  
                }
               
            }
        }

        IncomeSlider.value -=0.01f;
        IncomeEquality = (int)IncomeSlider.value;
        EducationSlider.value -= 0.01f;
        EducationEquality = (int)EducationSlider.value;
        GenderSlider.value -= 0.01f; 
        GenderEquality = (int)GenderSlider.value;
        ReligionSlider.value -= 0.01f;
        ReligionEquality = (int)ReligionSlider.value;

        Money.text = "" + IncomeEquality;
        Gender.text = "" + GenderEquality;
        Religion.text = "" + ReligionEquality;
        Education.text = "" + EducationEquality;


        CheckForZero();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite ==obstaclepool.CollectableSprites[0])
         {
            IncomeSlider.value += (int)Random.Range(1f, 4.9f);
            IncomeEquality=(int) IncomeSlider.value;
            Money.text = "" + IncomeEquality;
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[1])
        {
            EducationSlider.value += (int)Random.Range(1f, 4.9f);
            EducationEquality=(int)EducationSlider.value;
            Education.text = "" + EducationEquality;
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[2])
        {
            GenderSlider.value += (int)Random.Range(1f, 4.9f);
            GenderEquality =(int) GenderSlider.value;
            Gender.text = "" + GenderEquality;
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[3])
        {
            ReligionSlider.value += (int)Random.Range(1f, 4.9f);
            ReligionEquality=(int)ReligionSlider.value;
            Religion.text = "" + ReligionEquality;
        }
        check();
        collision.gameObject.SetActive(false);
    }

    public void check()
    {
        if(IncomeEquality>PlayerGoals.Instance.MaxIncomeEquality||GenderEquality>PlayerGoals.Instance.MaxGenderEquality||ReligionEquality>PlayerGoals.Instance.MaxReligionEquality||EducationEquality>PlayerGoals.Instance.MaxEducationEquality)
        {
            //gameover
            gameover();
        }
    }

    void gameover()
    {
        Blur_Bg.SetActive(true);
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[4].Name);
        if(Timer.score >=PlayerPrefs.GetInt("HS"))
        {
            PlayerPrefs.SetInt("HS", (int)Timer.score);
        }

        YourScore.text = "Your Score:" + (int)Timer.score;
        HighScore.text = "Your Score:" + PlayerPrefs.GetInt("HS");
    }

    public void CheckForZero()
    {
        if (IncomeEquality <=0.9|| GenderEquality <= 0.9 || ReligionEquality <= 0.9 || EducationEquality <= 0.9)
        {
            //gameover
            gameover();
        }
    }
    

}
