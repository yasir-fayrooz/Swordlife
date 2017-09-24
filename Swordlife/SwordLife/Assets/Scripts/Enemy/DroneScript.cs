using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour {

    private Rigidbody2D DroneRigidbody;
    private bool spawnSide;
    private bool CollisionDetect = false;
    private bool DroneShock = false;
    private Animator myAnimator;

    [SerializeField]
    public static float movementSpeed = 250;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVol");
        DroneRigidbody = GetComponent<Rigidbody2D>();
        spawnSide = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().spawnSide;
        spawnArea();
        myAnimator = gameObject.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
        HandleSounds();
        offScreen();
        HandleShock();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LaserShot1" || col.tag == "LaserShot" || col.tag == "Saw")
        {
            CollisionDetect = false;
        }
        else
        {
            CollisionDetect = true;
        }
        if(col.tag == "BoxCollider")
        {
            DroneShock = true;
        }
    }

    private void HandleMovement()
    {
        if (spawnSide)
        {
            if (DroneShock || CollisionDetect == true)
            {
                DroneRigidbody.velocity = Vector2.right * 0;
            } else
            {
                DroneRigidbody.velocity = Vector2.right * DroneScript.movementSpeed;
            }
        }
        if(spawnSide == false)
        {
            if (DroneShock || CollisionDetect == true)
            {
                DroneRigidbody.velocity = Vector2.left * 0;
            }
            else
            {
                DroneRigidbody.velocity = Vector2.left * DroneScript.movementSpeed;
            }
        }
    }

    private void HandleSounds()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVol");
        if (PauseMenu.paused)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
        else if (PauseMenu.paused == false)
        {
            gameObject.GetComponent<AudioSource>().UnPause();
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

    public void DroneFlySound()
    {
        FindObjectOfType<AudioManager>().Play("DroneFlyAway");
    }
}
