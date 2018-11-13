using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLooping: MonoBehaviour
{
    public float bgLayerSpeed;
    Transform bgCameraTransform;
   
    public GameObject bgPrevious;
    public GameObject bgCurrent;
    public GameObject bgNext;

    float bgDeltaX;
    float bgLastCameraX;

    public float bgSize;
    float ViewZone = 10;
    int LeftIndex;
    int RightIndex;


    private void Start()
    {
        bgCameraTransform = Camera.main.transform;
        bgLastCameraX = bgCameraTransform.position.y;
        bgCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        bgDeltaX = bgCameraTransform.position.y - bgLastCameraX;
        transform.position += Vector3.down * (bgDeltaX * bgLayerSpeed);
        bgLastCameraX = bgCameraTransform.position.y;
        
        if (bgCameraTransform.position.y > (bgNext.transform.position.y))
        {
            bgScrollRight();
            Debug.Log("scrolling right");
        }
    }





   

    public void bgScrollRight()
    {
        GameObject tempcurrent;
        tempcurrent = bgPrevious;
        bgPrevious = bgCurrent;
        bgCurrent = bgNext;
        bgNext = tempcurrent;
        //do
        //{
        //    bgNext = gamemanger.RandomSelectionOfBg();

        //} while (bgPrevious != bgNext &&bgCurrent != bgNext);

        bgNext.transform.position = bgCurrent.transform.position + bgSize * Vector3.up;

        
    }

}