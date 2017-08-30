using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour {

    private Rigidbody2D sawRigidbody;
    private bool spawnSide;
    [SerializeField]
    public static float movementSpeed = 400;

	// Use this for initialization
	void Start ()
    {
        sawRigidbody = GetComponent<Rigidbody2D>();
        spawnSide = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().spawnSide;
        spawnArea();
    }

	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
        HandleSounds();
        offScreen();
	}

    private void HandleMovement()
    {
        if (spawnSide)
        {
            sawRigidbody.velocity = Vector2.right * SawScript.movementSpeed;

        }
        if(spawnSide == false)
        {
            sawRigidbody.velocity = Vector2.left * SawScript.movementSpeed;
        }
    }

    private void HandleSounds()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVol");
        if (PauseMenu.paused)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
        else if(PauseMenu.paused == false)
        {
            gameObject.GetComponent<AudioSource>().UnPause();
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
