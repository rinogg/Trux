using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour {

    public GameObject explosion;
    public Vector3 spawnLocation;
    public Vector3 spawnLocation2;
    public Vector3 spawnLocation3;
    public Transform car;
    public bool exploded;
	
	
	// Update is called once per frame
	void Update () {


        if (ScrollingStreet.isDead == true & exploded == false)
        {   
            
            exploded = true;
            Instantiate(explosion, spawnLocation, Quaternion.identity);
            Instantiate(explosion, spawnLocation2, Quaternion.identity);
            Instantiate(explosion, spawnLocation3, Quaternion.identity);
           

        }

        else if (ScrollingStreet.isDead == false)
        {
            spawnLocation = new Vector3(car.position.x, car.position.y, -2f);
            spawnLocation2 = new Vector3(car.position.x + 1f, car.position.y + 1f, -2f);
            spawnLocation3 = new Vector3(car.position.x - 1f, car.position.y -0.2f, -2f);
        }
	}
}
