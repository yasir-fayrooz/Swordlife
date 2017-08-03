using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // swipe stuff
    public float maxTime;
    public float minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDistance;
    float swipeTime;

    //player stuff
    private bool facingRight;
    //animator
    private Animator myAnimator;



    // Use this for initialization
    void Start() {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    swipe();
                }
            }
        }
    }
    public void swipe()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //Horizontal swipes ----------

            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");

                //flip player
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

                myAnimator.SetBool("swipeAttack", true);
                myAnimator.SetBool("swipeAttack", false);

            }
            if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
                if (facingRight)
                {
                    //flip character scale
                    facingRight = false;
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    
                }
                myAnimator.SetBool("swipeAttack", true);
                myAnimator.SetBool("swipeAttack", false);
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            //Vertical swipes ----------------
        }
        if (distance.y < 0)
        {
            Debug.Log("Down Swipe");
            myAnimator.SetBool("swipeDuck", true);
            myAnimator.SetBool("swipeDuck", false);
        }
        if (distance.y > 0)
        {
            Debug.Log("Up Swipe");
            myAnimator.SetBool("swipeJump", true);
            myAnimator.SetBool("swipeJump", false);
        }
    }
}