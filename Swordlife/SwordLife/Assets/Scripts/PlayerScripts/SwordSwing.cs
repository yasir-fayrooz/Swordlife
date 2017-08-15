using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordSwing : MonoBehaviour {
    private scoreCount scoreCount;
    private PlayerHealth PlayerHP;

    void Start()
    {
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw")
        {
            PlayerHP.Damage(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Drone")
        {
            scoreCount.score += 1;
            Destroy(col.gameObject);
        }
    }
}
