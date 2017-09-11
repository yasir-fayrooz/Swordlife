using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour {

    private Animator myAnimator;
    private scoreCount scoreCount;
    private bool BackGround1to2 = true;
    private bool BackGround2to3 = true;
    private bool BackGround3to4 = true;
    private bool BackGround4to5 = true;
    private bool BackGround5to6 = true;

    // Use this for initialization
    void Start () {
        myAnimator = gameObject.GetComponent<Animator>();
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (scoreCount.score == 15 && BackGround1to2)
        {
            myAnimator.Play("Background_Animation2");
            PlaySound();
        }
        else if(scoreCount.score == 30 && BackGround2to3)
        {
            myAnimator.Play("Background_Animation3");
            PlaySound();
        }
        else if (scoreCount.score == 45 && BackGround3to4)
        {
            myAnimator.Play("Background_Animation4");
            PlaySound();
        }
        else if (scoreCount.score == 60 && BackGround4to5)
        {
            myAnimator.Play("Background_Animation5");
            PlaySound();
        }
        else if (scoreCount.score == 75 && BackGround5to6)
        {
            myAnimator.Play("Background_Animation6");
            PlaySound();
        }
    }
    private void PlaySound()
    {
        if(scoreCount.score == 15 && BackGround1to2)
        {
            FindObjectOfType<AudioManager>().Play("ChangeColour");
            BackGround1to2 = false;
        }
        else if (scoreCount.score == 30 && BackGround2to3)
        {
            FindObjectOfType<AudioManager>().Play("ChangeColour");
            BackGround2to3 = false;
        }
        else if (scoreCount.score == 45 && BackGround3to4)
        {
            FindObjectOfType<AudioManager>().Play("ChangeColour");
            BackGround3to4 = false;
        }
        else if (scoreCount.score == 60 && BackGround4to5)
        {
            FindObjectOfType<AudioManager>().Play("ChangeColour");
            BackGround4to5 = false;
        }
        else if (scoreCount.score == 75 && BackGround5to6)
        {
            FindObjectOfType<AudioManager>().Play("ChangeColour");
            BackGround5to6 = false;
        }
    }
}
