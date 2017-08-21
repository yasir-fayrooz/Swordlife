using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour {

    public GameObject scorecount;
    public GameObject YourScoreWas;
    public Text Highscore;

    public float score;

    void Start()
    {
        score = 0f;
        scorecount.GetComponent<Text>().text = score.ToString();
    }
    void Update()
    {
        scorecount.GetComponent<Text>().text = score.ToString();
        YourScoreWas.GetComponent<Text>().text = "Score: " + score.ToString();
        Highscore.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }
}
