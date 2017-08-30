using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject Highscore;
    public GameObject BackGround;

    public Slider[] volumeSliders;

    void Start()
    {
        Highscore.GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        BackGround.GetComponent<Animator>().Play("Pan_BackGround");
    }

    public void Play()
    {
        SceneManager.LoadScene("game");
        LaserShot.movementSpeed = 400;
        DroneScript.movementSpeed = 250;
        SawScript.movementSpeed = 400;
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        Application.Quit();
    }

    public void Options()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }
}
