using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject player;
    public GameObject[] powerUps;

    public float spawnTime = 5f;
    public float spawnDist = 25f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + spawnDist);
    }

    void SpawnObject()
    {
        int randIndx = Random.Range(0, spawnPoints.Length);
        //Debug.Log(spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randIndx];
        int randPowerUp = Random.Range(0, powerUps.Length); 
        GameObject powerUp = powerUps[randPowerUp];
        //Debug.Log(spawnPoint.name);
        Instantiate(powerUp, spawnPoint.position,spawnPoint.rotation);
    }
}
