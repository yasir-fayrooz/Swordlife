using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour {

    private Animator myAnimator;
    private scoreCount scoreCount;

	// Use this for initialization
	void Start () {
        myAnimator = gameObject.GetComponent<Animator>();
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (scoreCount.score == 15)
        {
            myAnimator.Play("Background_Animation2");
        }
        else if(scoreCount.score == 30)
        {
            myAnimator.Play("Background_Animation3");
        }
        else if (scoreCount.score == 45)
        {
            myAnimator.Play("Background_Animation4");
        }
        else if (scoreCount.score == 60)
        {
            myAnimator.Play("Background_Animation5");
        }
        else if (scoreCount.score == 75)
        {
            myAnimator.Play("Background_Animation5");
        }
    }
}
