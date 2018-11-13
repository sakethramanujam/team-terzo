using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstaclepool : MonoBehaviour
{
    //  public GameObject columnPrefab;                                 //The column game object.
    int columnPoolSize;                               //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public List<GameObject> columns = new List<GameObject>();
                                    //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     //A holding position for our unused columns offscreen.

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;
        columnPoolSize = columns.Count;
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
            timeSinceLastSpawned += Time.deltaTime;

            if (timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0f;

                //Set a random y position for the column
                float spawnYPosition = Random.Range(5f,10f);
            float spawnXPosition = Random.Range(-1f, +1f);

                //...then set the current column to that position.
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

                //Increase the value of currentColumn. If the new size is too big, set it back to zero
                currentColumn++;

                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
        }
    }
}