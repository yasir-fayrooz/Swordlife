using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 3;
    public int currentHealth;

    [SerializeField]
    private GameObject gameOverUI;
    
	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
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
        gameObject.GetComponent<Animator>().Play("Die_Animation");
        gameOverUI.SetActive(true);
    }
}
