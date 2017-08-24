using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {
    private Animator LaserShotAnim;
    private Rigidbody2D LaserShotRigidBody;

    [SerializeField]
    public static float movementSpeed = 400;

    void Start()
    {
        LaserShotAnim = gameObject.GetComponent<Animator>();
        LaserShotRigidBody = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        HandleMovement();
        offScreen();
    }

    void TransitionToSecondAnim()
    {
        LaserShotAnim.SetBool("FinishWoosh", true);
    }
    private void HandleMovement()
    {
        if (gameObject.tag == "LaserShot1")
        {
            LaserShotRigidBody.velocity = Vector2.right * LaserShot.movementSpeed;

        }
        if (gameObject.tag == "LaserShot")
        {
            LaserShotRigidBody.velocity = Vector2.left * LaserShot.movementSpeed;
        }
    }

    void offScreen()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(gameObject);
    }
}
