using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawn : MonoBehaviour {

    public GameObject truk;
    public float randomSpawnRate;
    public float randomPosition;
    public float nextSpawn = 1.0f;
    public Vector3 spawnLocation;
    public GameObject truckinstance;

	
	// Update is called once per frame
	void Update () {
        randomSpawnRate = Random.Range(1f, 3f);
        randomPosition = Random.Range(-2.33f, 2.33f);
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + randomSpawnRate;
            spawnLocation = new Vector3(randomPosition, 50f, -1f);
            truckinstance = Instantiate(truk, spawnLocation, Quaternion.identity) as GameObject;
        }
	}
}
