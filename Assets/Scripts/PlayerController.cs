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


    public Obstaclepool obstaclepool;

    void Start()
    {
        IncomeEquality = (int)Random.Range(20, PlayerGoals.Instance.MaxIncomeEquality/2);
        GenderEquality = (int)Random.Range(20, PlayerGoals.Instance.MaxGenderEquality/2);
        ReligionEquality = (int)Random.Range(70, PlayerGoals.Instance.MaxReligionEquality/2);
        EducationEquality = (int)Random.Range(70, PlayerGoals.Instance.MaxReligionEquality/2);


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

        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
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

       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        

         if(collision.gameObject.GetComponent<SpriteRenderer>().sprite ==obstaclepool.CollectableSprites[0])
         {

         }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[1])
        {

        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[2])
        {

        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == obstaclepool.CollectableSprites[3])
        {

        }

    }



}
