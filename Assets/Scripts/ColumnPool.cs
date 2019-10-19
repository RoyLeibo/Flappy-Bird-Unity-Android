using System.Collections;
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
    private GameObject[] columns1;
    private GameObject[] columns2;
    private GameObject firstColumn1;
    private GameObject firstColumn2;
    private bool isFirstColumnDestroyed = false;
    private Vector2 objPoolPos = new Vector2(-15f,-25f);
    
    void Start()
    {
        //create the pool
        columns1 = new GameObject[poolSize];
        for (int i=0;i<poolSize;i++){
            columns1[i] = (GameObject)Instantiate(columnsPrefab,objPoolPos,Quaternion.identity);
        }
        firstColumn1 = (GameObject)Instantiate(columnsPrefab,new Vector2(spawnXPos,0),Quaternion.identity);
        if(!GameControl.isSingle)
        {
            columns2 = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                columns2[i] = (GameObject)Instantiate(columnsPrefab, objPoolPos, Quaternion.identity);
            }
            firstColumn2 = (GameObject)Instantiate(columnsPrefab, new Vector2(spawnXPos, -16), Quaternion.identity);
        }
    }

    
    void Update()
    {
        //if game isn't over,when spawnRate time passed, spawn new element.
        timeSinceLastSpawn += Time.deltaTime;
        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate){
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(columnYMin,columnYMax);
            columns1[currentColumn].transform.position = new Vector2(spawnXPos,spawnYPos);
            if (!GameControl.isSingle)
            {
                columns2[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos - 16);
            }
            currentColumn++;
            if(currentColumn>=poolSize){
                currentColumn = 0;
                //if not destroyed, destroy the first column.
                if(!isFirstColumnDestroyed){
                    Destroy(firstColumn1);
                    if (!GameControl.isSingle)
                    {
                        Destroy(firstColumn2);
                    }
                    isFirstColumnDestroyed = true;
                }
            }
        }
    }
}
