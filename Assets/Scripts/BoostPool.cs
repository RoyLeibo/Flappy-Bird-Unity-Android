using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoostPool : MonoBehaviour
{
    public float[] spawnRates;
    public int poolSize = 5;
    public float boostYMin = -2.5f;
    public float boostYMax = 2.5f;

    private float timeSinceLastSpawn = 0;
    private float spawnXPos = 10f;
    private int currentBoost = 0;
    private int currentSpawn = 0;
    public GameObject[] boosts;
    private GameObject[] boostsPool1;
    private GameObject[] boostsPool2;
    private Vector2 objPoolPos = new Vector2(-15f, -25f);
    System.Random rand = new System.Random();
    void Start()
    {
        //create the pool
        boostsPool1 = new GameObject[poolSize];
        if (!GameControl.isSingle)
        {
            boostsPool2 = new GameObject[poolSize];
        }
        for (int i = 0; i < poolSize; i++)
        {
            int whichBoost = rand.Next(0, boosts.Length);
            boostsPool1[i] = (GameObject)Instantiate(boosts[whichBoost], objPoolPos, Quaternion.identity);
            if (!GameControl.isSingle)
            {
                boostsPool2[i] = (GameObject)Instantiate(boosts[whichBoost], objPoolPos, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        //if game isn't over,when spawnRate time passed, spawn new element.
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRates[currentSpawn])
        {
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(boostYMin, boostYMax);
            float r = Random.Range(1.5f, 4.5f); // the addition so that the boost wouldn't collide the columns.
            boostsPool1[currentBoost].transform.position = new Vector2(spawnXPos + r, spawnYPos);
            //make trigger and visibility enabled again.
            boostsPool1[currentBoost].GetComponent<Collider2D>().enabled = true;
            boostsPool1[currentBoost].GetComponent<Renderer>().enabled = true;
            if (!GameControl.isSingle)
            {
                boostsPool2[currentBoost].transform.position = new Vector2(spawnXPos + r, spawnYPos - 16);
                boostsPool2[currentBoost].GetComponent<Collider2D>().enabled = true;
                boostsPool2[currentBoost].GetComponent<Renderer>().enabled = true;
            }
            currentBoost++;
            currentSpawn = rand.Next(0, spawnRates.Length);
            if (currentBoost >= poolSize) { currentBoost = 0; }
        }
    }
}