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
    private GameObject[] columns;
    private Vector2 objPoolPos = new Vector2(-15f,-25f);
    
    void Start()
    {
        columns = new GameObject[poolSize];
        for(int i=0;i<poolSize;i++){
            columns[i] = (GameObject)Instantiate(columnsPrefab,objPoolPos,Quaternion.identity);
        }
    }

    
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate){
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(columnYMin,columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos,spawnYPos);
            currentColumn++;
            if(currentColumn>=poolSize){currentColumn = 0;}
        }
    }
}
