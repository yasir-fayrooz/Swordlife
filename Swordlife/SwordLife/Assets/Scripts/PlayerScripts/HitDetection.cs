using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour {

    private GameObject Player;
    private PlayerHealth PlayerHP;

    // Use this for initialization
    void Start () 
	{
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
            PlayerHP.Damage(1);
			Destroy(col.gameObject);
    }
}
