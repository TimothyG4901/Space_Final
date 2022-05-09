using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public GameObject ObjectPrefab;                                    //The column game object.
    public int columnPoolSize = 3;                                    //How many columns to keep on standby.
    public float spawnRate = 2f;                                    //How quickly columns spawn.
    public float columnMin = 0f;                                    //Minimum y value of the column position.
    public float columnMax = 0f;                                    //Maximum y value of the column position.

    private GameObject[] columns;                                    //Collection of pooled columns.
    private int currentColumn = 0;                                    //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;


        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
        {

            columns[i] = (GameObject)Instantiate(ObjectPrefab, objectPoolPosition, Quaternion.identity);
        }
    }



    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;


            float spawnYPosition = Random.Range(columnMin, columnMax);


            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);


            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}