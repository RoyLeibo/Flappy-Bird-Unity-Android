using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoostPool : MonoBehaviour
{
    //TODO: continue naming variables and choosing values.
    public float spawnRate = 4f;
    public int poolSize = 5;
    public float boostYMin = -1.1f;
    public float boostYMax = 0.9f;

    private float timeSinceLastSpawn = 0;
    private float spawnXPos = 7f;
    private int currentBoost = 0;
    public GameObject[] boosts;
    private GameObject[] boostsPool;
    private Vector2 objPoolPos = new Vector2(-15f,-25f);
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        boostsPool = new GameObject[poolSize];
        for(int i=0;i<poolSize;i++){
            int whichBoost = rand.Next(0,boosts.Length);
            boostsPool[i] = (GameObject)Instantiate(boosts[whichBoost],objPoolPos,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate){
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(boostYMin,boostYMax);
            float xRange = spawnRate*1.5f - 1f; // spawnRate *1.5 / 2 - boost size.
            spawnXPos = spawnXPos + Random.Range(1,xRange);
            boostsPool[currentBoost].transform.position = new Vector2(spawnXPos,spawnYPos);
            currentBoost++;
            if(currentBoost>=poolSize){currentBoost = 0;}
        }
    }
}
