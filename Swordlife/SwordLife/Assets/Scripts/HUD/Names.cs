using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Names : MonoBehaviour {
    private Text Text;

    void Update()
    {
        Text = gameObject.GetComponent<Text>();
    }
    public void ChangeName()
    {

        //Names
        if(Text.text == "Yasir Fayrooz")
        {
            Text.text = "Nicholas Bader";
        }
        else if(Text.text == "Nicholas Bader")
        {
            Text.text = "Reece Karslake";
        }
        else if (Text.text == "Reece Karslake")
        {
            Text.text = "Yasir Fayrooz";
        }


        //Roles
        if (Text.text == "Lead Programmer Animator")
        {
            Text.text = "Lead Artist + Sprite guy";
        }
        else if (Text.text == "Lead Artist + Sprite guy")
        {
            Text.text = "Lead UI Designer + Programmer";
        }
        else if (Text.text == "Lead UI Designer + Programmer")
        {
            Text.text = "Lead Programmer Animator";
        }
    }
}
