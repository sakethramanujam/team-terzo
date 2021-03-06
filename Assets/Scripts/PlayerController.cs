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


    public Text GMoney;
    public Text GGender;
    public Text GReligion;
    public Text GEducation;

    public Text YourScore, HighScore;


    private bool IsGameOver=false;


    public Slider GIncomeSlider;
    public Slider GGenderSlider;
    public Slider GEducationSlider;
    public Slider GReligionSlider;


    void Start()
    {
        IsGameOver = false;
       
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.GameSounds[2]);
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

        if (!IsGameOver)
        {
            IncomeSlider.value -= 0.01f;
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

        }
        CheckForZero();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite ==obstaclepool.CollectableSprites[0])
         {
            IncomeSlider.value += (int)Random.Range(1f, 4.9f);
            IncomeEquality=(int) IncomeSlider.value;
            Money.text = "" + IncomeEquality;
            SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[5].Name);
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[1])
        {
            EducationSlider.value += (int)Random.Range(1f, 4.9f);
            EducationEquality=(int)EducationSlider.value;
            Education.text = "" + EducationEquality;
            SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[8].Name);
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[2])
        {
            GenderSlider.value += (int)Random.Range(1f, 4.9f);
            GenderEquality =(int) GenderSlider.value;
            Gender.text = "" + GenderEquality;
            SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[6].Name);
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[3])
        {
            ReligionSlider.value += (int)Random.Range(1f, 4.9f);
            ReligionEquality=(int)ReligionSlider.value;
            Religion.text = "" + ReligionEquality;
            SoundManager.Instance.PlaySound(SoundManager.Instance.GameSounds[7].Name);
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
        IsGameOver = true;
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);

        GIncomeSlider.maxValue = 100;
        GIncomeSlider.minValue = 0;
        GIncomeSlider.value = IncomeEquality;

        GGenderSlider.maxValue = 100;
        GGenderSlider.minValue = 0;
        GGenderSlider.value = GenderEquality;

        GEducationSlider.maxValue = 100;
        GEducationSlider.minValue = 0;
        GEducationSlider.value = EducationEquality;

        GReligionSlider.maxValue = 100;
        GReligionSlider.minValue = 0;
        GReligionSlider.value = ReligionEquality;


        GMoney.text = "" + IncomeEquality;
        GGender.text = "" + GenderEquality;
        GReligion.text = "" + ReligionEquality;
        GEducation.text = "" + EducationEquality;


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
