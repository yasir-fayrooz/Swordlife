using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlusOnExit : MonoBehaviour
{
    //Count score and level:
    private scoreCount scoreCount;
    public GameObject LevelUp;
    private AudioSource[] MyMusic;

    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>();
        MyMusic = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainMenuCamera>().sounds;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Saw")
        {
            scoreCount.score += 1;
            FindObjectOfType<AudioManager>().Play("ScorePoint");
            if (scoreCount.score % 5 == 0)
            {
                scoreCount.level += 1;
                MyMusic[0].pitch = MyMusic[0].pitch + 0.02f;
                FindObjectOfType<AudioManager>().Play("LevelUp");
                Instantiate(LevelUp, new Vector3(0, -90), Quaternion.identity);
                LaserShot.movementSpeed += 20;
                SawScript.movementSpeed += 10;
                DroneScript.movementSpeed += 10;
            }
        }
        if (col.tag == "LaserShot" || col.tag == "LaserShot1")
        {
            scoreCount.score += 1;
            FindObjectOfType<AudioManager>().Play("ScorePoint");
            if (scoreCount.score % 5 == 0)
            {
                scoreCount.level += 1;
                MyMusic[0].pitch = MyMusic[0].pitch + 0.02f;
                FindObjectOfType<AudioManager>().Play("LevelUp");
                Instantiate(LevelUp, new Vector3(0, -90), Quaternion.identity);
                LaserShot.movementSpeed += 20;
                SawScript.movementSpeed += 10;
                DroneScript.movementSpeed += 10;
            }
        }
    }
}