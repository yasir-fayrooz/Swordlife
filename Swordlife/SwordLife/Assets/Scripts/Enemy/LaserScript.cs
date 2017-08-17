using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    private Rigidbody2D LaserRigidbody;
    private bool spawnSide;

	// Use this for initialization
	void Start ()
    {
        LaserRigidbody = GetComponent<Rigidbody2D>();
        spawnSide = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().spawnSide;
        spawnArea();
    }
    void spawnArea()
    {
        if (spawnSide == false)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void offScreen()
    {
            Destroy(gameObject);
    }
}
