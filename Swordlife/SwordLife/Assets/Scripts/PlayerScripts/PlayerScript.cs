using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    //player stuff
    private bool facingRight;
    private bool attack;
    private bool jump;
    private bool duck;
    //animator
    private Animator myAnimator;
    public GameObject GameOverUI;

    // turn player to the left
    private float PlayerScale;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        PlayerScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update () {
        if (GameOverUI.activeInHierarchy)
        {
            return;
        }

        //handles all controls
        HandleInput();
        HandleAnimations();
        flip();
        ResetValues();

    }

    private void HandleInput()
    {
        if (Controls.swipeDirection == Swipe.Left)
        {
            attack = true;
        }
        if (Controls.swipeDirection == Swipe.Right)
        {
            attack = true;
        }
        if (Controls.swipeDirection == Swipe.Up)
        {
            jump = true;
        }
        if (Controls.swipeDirection == Swipe.Down)
        {
            duck = true;
        }
    }
    private void HandleAnimations()
    {
        if (attack)
        {
            myAnimator.SetTrigger("swipeAttack");
        }
        if (jump)
        {
            myAnimator.SetTrigger("swipeJump");
        }
        if (duck)
        {
            myAnimator.SetTrigger("swipeDuck");
        }
    }
    private void flip()
    {

        if (Controls.swipeDirection == Swipe.Right)
        {
            //flip character scale
            if (facingRight)
            {
                facingRight = true;
            }
            else {
                FindObjectOfType<AudioManager>().Play("TurnSound");
                transform.localScale = new Vector3(-PlayerScale, transform.localScale.y);
                facingRight = true;
            }
        }
        if (Controls.swipeDirection == Swipe.Left)
        {
            if (facingRight)
            {
                //flip character scale
                facingRight = false;
                FindObjectOfType<AudioManager>().Play("TurnSound");
                transform.localScale = new Vector3(+PlayerScale, transform.localScale.y);
            }
        }
    }

    private void ResetValues()
    {
        attack = false;
        jump = false;
        duck = false;
    }

    public void AttackSound()
    {
        FindObjectOfType<AudioManager>().Play("AttackSound");
    }
    public void Jump1Sound()
    {
        FindObjectOfType<AudioManager>().Play("Jump1");
    }
    public void Jump2Sound()
    {
        FindObjectOfType<AudioManager>().Play("Jump2");
    }
    public void DuckSound()
    {
        FindObjectOfType<AudioManager>().Play("DuckSound");
    }
}
