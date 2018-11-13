using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MoveDistance = 150;

    private int playerPosition = 1;

    private void Update()
    {
        // if D key is pressed down
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPosition < 2)
            {
                // move the player along the positive Z axis
                transform.Translate(MoveDistance,0,0);
                // increment the player position
                playerPosition++;
            }
        }
        // if A key is pressed down
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPosition > 0)
            {
                // move the player along the negative Z axis
                transform.Translate(-MoveDistance,0, 0);
                // decrement the player position
                playerPosition--;
            }
        }
    }
}
