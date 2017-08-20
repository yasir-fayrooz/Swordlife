using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour{

    public GameObject BackgroundMusic;
    public GameObject HUD;


    void Start()
    {
        BackgroundMusic.GetComponent<AudioSource>().Stop();
        HUD.GetComponent<Animator>().Play("HUD_Fade");
    }

}
