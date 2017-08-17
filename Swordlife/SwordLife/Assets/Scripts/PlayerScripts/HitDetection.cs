using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour {

    private PlayerHealth PlayerHP;

    // Use this for initialization
    void Start () 
	{
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Saw")
        {
            PlayerHP.Damage(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Drone")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Shock_Animation");
            PlayerHP.Damage(1);
        }
    }
}
