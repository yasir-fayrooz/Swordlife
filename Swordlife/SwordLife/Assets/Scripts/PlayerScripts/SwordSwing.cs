using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwordSwing : MonoBehaviour {
	public GameObject scorecount;
	public float score;
	void Start()
	{
		score = 0f;
		scorecount.GetComponent<Text>().text = score.ToString();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw")
        {
			score+=1f;
        }
    }
}
