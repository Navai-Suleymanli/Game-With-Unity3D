using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnpos = new Vector3(25, 0, 0);
    public float startDelay = 2;
    public float spawnInterval = 2;
    private PlayerController playerControllerScript;
    private int randomObstacle;

    // Start is called before the first frame update
    void Start()
    {
        // added playercontroller script to our variable
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval); // repeats function after sometime in given interval
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() 
    {
        if(playerControllerScript.gameOver == false) 
        {
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomObstacle], spawnpos, obstaclePrefabs[randomObstacle].transform.rotation);
        }
        
    }
}
