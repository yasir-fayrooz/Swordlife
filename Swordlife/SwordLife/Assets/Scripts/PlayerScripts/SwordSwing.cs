using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordSwing : MonoBehaviour {
    private scoreCount scoreCount;
    private PlayerHealth PlayerHP;
    public GameObject LevelUp;


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
            FindObjectOfType<AudioManager>().Play("DroneDestroy");
            GameObject.FindGameObjectWithTag("Drone").GetComponent<Animator>().Play("Drone_DestroyOnHit");
            scoreCount.score += 1;
            FindObjectOfType<AudioManager>().Play("ScorePoint");
            if (scoreCount.score % 5 == 0)
            {
                scoreCount.level += 1;
                FindObjectOfType<AudioManager>().Play("LevelUp");
                Instantiate(LevelUp, new Vector3(0, -90), Quaternion.identity);
                LaserShot.movementSpeed += 20;
                SawScript.movementSpeed += 10;
                DroneScript.movementSpeed += 10;
            }
        }
    }
}
