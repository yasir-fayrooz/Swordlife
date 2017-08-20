using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour{

    public GameObject BackgroundMusic;


    void Start()
    {
        BackgroundMusic.GetComponent<AudioSource>().Stop();
    }

}
