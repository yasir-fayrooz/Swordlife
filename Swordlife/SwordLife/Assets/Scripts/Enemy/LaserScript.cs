using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    private Rigidbody2D LaserRigidbody;
    private bool spawnSide;
    public Transform Lasershot;
    public Transform Lasershot1;
    public int LaserSpawn;

	// Use this for initialization
	void Start ()
    {
        spawnSide = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().spawnSide;
        spawnArea();
    }
    void spawnArea()
    {
        if (spawnSide)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            LaserSpawn = -320;
        }
        else if (spawnSide == false)
        {
            LaserSpawn = 320;
        }
    }

    void offScreen()
    {
            Destroy(gameObject);
    }

    void Shoot()
    {
        if (LaserSpawn == -320)
        {
            Instantiate(Lasershot1, new Vector3(LaserSpawn, -130), Quaternion.identity);
        }
        else if(LaserSpawn == 320)
        {
            Instantiate(Lasershot, new Vector3(LaserSpawn, -130), Quaternion.identity);
        }

    }

}
