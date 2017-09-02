using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour {

    public GameObject scorecount;
    public GameObject levelcount;
    public GameObject YourScoreWas;
    public GameObject YourLevelWas;
    public GameObject Highscore;

    //volume sliders
    public GameObject MusicVolText;
    public GameObject SFXVolText;

    public float score;
    public int level;

    void Start()
    {
        score = 0f;
        level = 1;
        scorecount.GetComponent<Text>().text = score.ToString();
        levelcount.GetComponent<Text>().text = level.ToString();
    }
    void Update()
    {
        scorecount.GetComponent<Text>().text = score.ToString();
        levelcount.GetComponent<Text>().text = level.ToString();
        YourScoreWas.GetComponent<Text>().text = score.ToString();
        YourLevelWas.GetComponent<Text>().text = level.ToString();
        Highscore.GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();

        //Music
        float SFXVolDecimal = PlayerPrefs.GetFloat("SFXVol") * 100;
        float MusicVolDecimal = PlayerPrefs.GetFloat("MusicVol") * 100;
        int MusicVolLevel = (int)MusicVolDecimal;
        int SFXVolLevel = (int)SFXVolDecimal;
        SFXVolText.GetComponent<Text>().text = "SFX Volume: " + SFXVolLevel;
        MusicVolText.GetComponent<Text>().text = "Music Volume: " + MusicVolLevel;

    }
}
