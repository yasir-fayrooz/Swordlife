using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour {

    private Rigidbody2D sawRigidbody;

    [SerializeField]
    private float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        sawRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
        offScreen();
	}

    private void HandleMovement()
    {
        if (EnemyManager.spawnSide)
        {
            sawRigidbody.velocity = Vector2.right * movementSpeed;
        }
        if(EnemyManager.spawnSide == false)
        {
            sawRigidbody.velocity = Vector2.left * movementSpeed;
        }
    }

    void offScreen()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(gameObject);
    }
}
