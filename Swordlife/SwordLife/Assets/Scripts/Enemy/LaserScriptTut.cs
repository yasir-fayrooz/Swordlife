using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptTut : MonoBehaviour {

    private Rigidbody2D LaserRigidbody;
    public int LaserSpawn = -400;
    public GameObject LaserShot2;

	// Use this for initialization
	void Start ()
    {
    }

    void Shoot()
    {
        LaserShot2.SetActive(true);
    }
    void setActive()
    {
        gameObject.SetActive(false);
    }
}
