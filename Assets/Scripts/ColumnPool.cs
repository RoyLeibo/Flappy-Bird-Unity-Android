﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    
    public float spawnRate = 4f;
    public int poolSize = 5;
    public float columnYMin = -1.1f;
    public float columnYMax = 0.9f;

    private float timeSinceLastSpawn = 0;
    private float spawnXPos = 10f;
    private int currentColumn = 0;
    public GameObject columnsPrefab;
    private GameObject[] columns;
    private GameObject firstColumn;
    private bool isFirstColumnDestroyed = false;
    private Vector2 objPoolPos = new Vector2(-15f,-25f);
    
    void Start()
    {
        //create the pool
        columns = new GameObject[poolSize];
        for(int i=0;i<poolSize;i++){
            columns[i] = (GameObject)Instantiate(columnsPrefab,objPoolPos,Quaternion.identity);
        }
        firstColumn = (GameObject)Instantiate(columnsPrefab,new Vector2(spawnXPos,0),Quaternion.identity);
    }

    
    void Update()
    {
        //if game isn't over,when spawnRate time passed, spawn new element.
        timeSinceLastSpawn += Time.deltaTime;
        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate){
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(columnYMin,columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos,spawnYPos);
            currentColumn++;
            if(currentColumn>=poolSize){
                currentColumn = 0;
                //if not destroyed, destroy the first column.
                if(!isFirstColumnDestroyed){
                    Destroy(firstColumn);
                    isFirstColumnDestroyed = true;
                }
            }
        }
    }
}
