using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlusOnExit : MonoBehaviour
{
    //Count score and level:
    private scoreCount scoreCount;
    public GameObject LevelUp;

    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Saw")
        {
            scoreCount.score += 1;
            if (scoreCount.score % 5 == 0)
            {
                scoreCount.level += 1;
                Instantiate(LevelUp, new Vector3(0, -90), Quaternion.identity);
                LaserShot.movementSpeed += 20;
                SawScript.movementSpeed += 20;
                DroneScript.movementSpeed += 20;
            }
        }
        if (col.tag == "LaserShot" || col.tag == "LaserShot1")
        {
            scoreCount.score += 1;
            if (scoreCount.score % 5 == 0)
            {
                scoreCount.level += 1;
                Instantiate(LevelUp, new Vector3(0, -90), Quaternion.identity);
                LaserShot.movementSpeed += 20;
                SawScript.movementSpeed += 20;
                DroneScript.movementSpeed += 20;
            }
        }
    }
}