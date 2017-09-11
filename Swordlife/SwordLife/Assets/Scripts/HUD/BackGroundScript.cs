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

        if(scoreCount.score == 10)
        {
                myAnimator.Play("Background_Animation2");
        }
        else if(scoreCount.score == 20)
        {
            myAnimator.Play("Background_Animation3");
        }
   }
}
