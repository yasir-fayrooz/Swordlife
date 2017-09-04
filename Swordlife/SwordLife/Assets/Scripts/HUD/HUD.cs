using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerHealth playerHP;
    
    // Use this for initialization
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        FindObjectOfType<AudioManager>().Play("RunningLiquid");
    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[playerHP.currentHealth];
    }
}