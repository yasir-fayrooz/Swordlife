using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour {

    public GameObject scorecount;
    public GameObject YourScoreWas;
    public GameObject Highscore;

    public float score;

    void Start()
    {
        score = 0f;
        scorecount.GetComponent<Text>().text = score.ToString();
    }
    void Update()
    {
        scorecount.GetComponent<Text>().text = score.ToString();
        YourScoreWas.GetComponent<Text>().text = score.ToString();
        Highscore.GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }
}
