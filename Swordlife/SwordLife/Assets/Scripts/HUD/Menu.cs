using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject Highscore;

    public Slider[] volumeSliders;

    void Start()
    {
        Highscore.GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
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
        Application.Quit();
    }

    public void Options()
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {

    }

    public void SetSFXVolume(float value)
    {

    }
}
