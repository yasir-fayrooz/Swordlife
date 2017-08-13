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
    }

    void Update()
    {
        ScreenRotate();
        HeartUI.sprite = HeartSprites[playerHP.currentHealth];
    }

    void ScreenRotate()
    {
        if (Input.deviceOrientation == DeviceOrientation.FaceDown ||
            Input.deviceOrientation == DeviceOrientation.FaceUp ||
            Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

    }
}