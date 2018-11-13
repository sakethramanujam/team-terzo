using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    public float MoveDistance = 150;

    private int playerPosition = 1;

    void Start()
    {
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






        //// if D key is pressed down
        //if (Input.GetKeyDown(KeyCode.D))
        //{
           
        //}
        //// if A key is pressed downs
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
           
        //}
    }
}
