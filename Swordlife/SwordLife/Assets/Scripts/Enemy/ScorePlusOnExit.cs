using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlusOnExit : MonoBehaviour
{
    private scoreCount scoreCount;

    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Saw")
        {
            scoreCount.score += 1;
        }
    }
}