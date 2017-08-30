using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject PauseButton;
    public GameObject OptionsMenu;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (paused)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Pause();
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().UnPause();
            PauseUI.SetActive(true);
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        LaserShot.movementSpeed = 400;
        DroneScript.movementSpeed = 250;
        SawScript.movementSpeed = 400;
    }
    public void MainMenu()
    {
        paused = false;
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        PauseUI.transform.GetChild(0).gameObject.SetActive(false);
        PauseUI.transform.GetChild(1).gameObject.SetActive(false);
        PauseUI.transform.GetChild(2).gameObject.SetActive(false);
        PauseUI.transform.GetChild(3).gameObject.SetActive(false);
        PauseUI.transform.GetChild(5).gameObject.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void Back()
    {
        PauseUI.transform.GetChild(0).gameObject.SetActive(true);
        PauseUI.transform.GetChild(1).gameObject.SetActive(true);
        PauseUI.transform.GetChild(2).gameObject.SetActive(true);
        PauseUI.transform.GetChild(3).gameObject.SetActive(true);
        PauseUI.transform.GetChild(5).gameObject.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
