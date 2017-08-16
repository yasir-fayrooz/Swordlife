using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    // Use this for initialization
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
