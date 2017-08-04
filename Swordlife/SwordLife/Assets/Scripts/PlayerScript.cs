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

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //handles all controls
        HandleInput();
        HandleAnimations();
        ResetValues();


        if (Controls.swipeDirection == Swipe.Right)
        {
            //flip character scale
            if (facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= 1;
                transform.localScale = theScale;
            }
            else {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingRight = true;
            }
        }
        if (Controls.swipeDirection == Swipe.Left)
        {
            if (facingRight)
            {
                //flip character scale
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

            }
        }
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
    private void ResetValues()
    {
        attack = false;
        jump = false;
        duck = false;
    }
}
