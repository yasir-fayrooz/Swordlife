using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 3;
    public int currentHealth;
	public GameObject scorecounter;
	public float score;
    
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
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Saw")
		{
			score+=1;
			scorecounter.GetComponent<Text>().text = score.ToString();
			Destroy(col.gameObject);
		}
 	}

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Hit_Animation");
    }

    void Die()
    {
        SceneManager.LoadScene(2);
    }
}
