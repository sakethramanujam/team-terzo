using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Obstaclepool : MonoBehaviour
{
    public GameObject columnPrefab;                                 //The column game object.
    public int columnPoolSize = 5;                                  //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.

    public List<Sprite> CollectableSprites = new List<Sprite>();
    List<float> lanes = new List<float>();
    private GameObject[] columns;                                   //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     //A holding position for our unused columns offscreen.

    private float timeSinceLastSpawned;


    void Start()
    {
        lanes.Add(-1.5f);
        lanes.Add(1.5f);
        lanes.Add(0f);

        timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {

            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            columns[i].GetComponent<SpriteRenderer>().sprite = CollectableSprites[(int)Mathf.Abs(Random.Range(0.0f, 3.9f))];
        }
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
            timeSinceLastSpawned += Time.deltaTime;

            if (timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = this.transform.position.y;
            float spawnXPosition = lanes[(int)Mathf.Abs(Random.Range(0.0f, 2.9f))];
                //...then set the current column to that position.
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            columns[currentColumn].SetActive(true);
            columns[currentColumn].GetComponent<SpriteRenderer>().sprite = CollectableSprites[(int)Mathf.Abs(Random.Range(0.0f, 3.9f))];
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
        }
    }
}