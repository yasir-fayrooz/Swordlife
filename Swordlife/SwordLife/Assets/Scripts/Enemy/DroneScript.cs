using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour {

    private Rigidbody2D DroneRigidbody;
    private bool spawnSide;
    private bool DroneShock = false;
    private Animator myAnimator;

    [SerializeField]
    public float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        DroneRigidbody = GetComponent<Rigidbody2D>();
        spawnSide = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().spawnSide;
        spawnArea();
        myAnimator = gameObject.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
        offScreen();
        HandleShock();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BoxCollider")
        {
            DroneShock = true;
            movementSpeed = 0;
        }
    }

    private void HandleMovement()
    {
        if (spawnSide)
        {
            DroneRigidbody.velocity = Vector2.right * movementSpeed;

        }
        if(spawnSide == false)
        {
            DroneRigidbody.velocity = Vector2.left * movementSpeed;
        }
    }

    void DroneFly()
    {
        DroneShock = false;
        myAnimator.Play("Drone_Fly_Animation");
    }
    void DroneDestroy2()
    {
        Destroy(gameObject);
    }

    private void HandleShock()
    {
        if (DroneShock)
        {
            myAnimator.SetTrigger("DroneShock");
            myAnimator.Play("Drone_Shock_Anim");
        }
    }
    void spawnArea()
    {
        if (spawnSide)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void offScreen()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(gameObject);
    }
}
