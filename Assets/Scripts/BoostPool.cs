using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoostPool : MonoBehaviour
{
    //TODO: continue naming variables and choosing values.
    public float spawnRate = 5f;
    public int poolSize = 5;
    public float columnYMin = -1.1f;
    public float columnYMax = 0.9f;

    private float timeSinceLastSpawn = 0;
    private float spawnXPos = 7f;
    private int currentColumn = 0;
    public GameObject[] boosts;
    private GameObject[] boostsPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
