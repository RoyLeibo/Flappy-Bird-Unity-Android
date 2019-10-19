using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public float[] spawnRates;
    public int poolSize = 2;
    private int currentSpawn = 0;
    private float timeSinceLastSpawn = 0;
    private float spawnXPos = 10f;
    private int currentEnemy = 0;
    //change enemy to array of enemies if we have more enemies.
    //dont forget to modify start and update as well.
    public GameObject enemy;
    private GameObject[] enemyPool1;
    private GameObject[] enemyPool2;
    private Vector2 enemyPoolPos = new Vector2(-15f, -25f);
    System.Random rand = new System.Random();
    void Start()
    {
        //create the pool
        enemyPool1 = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            enemyPool1[i] = (GameObject)Instantiate(enemy, enemyPoolPos, Quaternion.identity);
        }
        if (!GameControl.isSingle)
        {
            enemyPool2 = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                enemyPool2[i] = (GameObject)Instantiate(enemy, enemyPoolPos, Quaternion.identity);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if game isn't over,when spawnRate time passed, spawn new element.
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRates[currentSpawn])
        {
            timeSinceLastSpawn = 0;
            float spawnYPos = 0;
            float r = Random.Range(1.75f, 4.25f); // the addition so that the boost wouldn't collide the columns.
            enemyPool1[currentEnemy].transform.position = new Vector2(spawnXPos + r, spawnYPos);
            //make trigger and visibility enabled again.
            enemyPool1[currentEnemy].GetComponent<Collider2D>().enabled = true;
            enemyPool1[currentEnemy].GetComponent<Renderer>().enabled = true;
            enemyPool1[currentEnemy].GetComponent<Enemy>().isDead = false;
            if (!GameControl.isSingle)
            {
                enemyPool2[currentEnemy].transform.position = new Vector2(spawnXPos + r, spawnYPos - 16);
                enemyPool2[currentEnemy].GetComponent<Collider2D>().enabled = true;
                enemyPool2[currentEnemy].GetComponent<Renderer>().enabled = true;
                enemyPool2[currentEnemy].GetComponent<Enemy>().isDead = false;
            }
            currentEnemy++;
            currentSpawn = rand.Next(0, spawnRates.Length);
            if (currentEnemy >= poolSize) { currentEnemy = 0; }
        }
    }
}