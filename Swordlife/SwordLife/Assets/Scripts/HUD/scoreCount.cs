using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour {

    public GameObject scorecount;
    public float score;

    void Start()
    {
        score = 0f;
        scorecount.GetComponent<Text>().text = score.ToString();
    }
    void Update()
    {
        scorecount.GetComponent<Text>().text = score.ToString();
    }
}
