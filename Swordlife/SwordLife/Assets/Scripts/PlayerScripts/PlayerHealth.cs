using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 3;
    public int currentHealth;
    
	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

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
        currentHealth -= dmg;
    }

    void Die()
    {
        SceneManager.LoadScene(2);
    }
}
