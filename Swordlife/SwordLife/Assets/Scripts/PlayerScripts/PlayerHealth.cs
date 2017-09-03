using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 3;
    public int currentHealth;
    public float score;

    private AudioSource[] sounds;
    private bool alreadyPlayed = false;
    private bool alreadyPlayed2 = false;

    [SerializeField]
    private GameObject gameOverUI;
    
	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
        sounds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HUD>().sounds;

    }
	
	// Update is called once per frame
	void Update () 
	{

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
	}

    public void Damage(int dmg)
    {
        gameObject.GetComponent<Animation>().Play("Hit_Animation");
        currentHealth -= dmg;
        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Animation>().Play("Health3-2");

    }

    void Die()
    {
        sounds[0].Stop();
        if (!alreadyPlayed)
        {
            sounds[2].Play();
            alreadyPlayed = true;
        }
        if (!sounds[2].isPlaying && !alreadyPlayed2)
        {
            sounds[1].Play();
            alreadyPlayed2 = true;
        }
        if(PlayerPrefs.GetFloat("Highscore") < GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>().score)
        {
            PlayerPrefs.SetFloat("Highscore", GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scoreCount>().score);
        }
        gameObject.GetComponent<Animator>().Play("Die_Animation");
        gameOverUI.SetActive(true);
    }
}
