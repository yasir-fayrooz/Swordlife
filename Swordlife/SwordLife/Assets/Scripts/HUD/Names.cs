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
        if (Text.text == "Alexander Baldwin")
        {
            Text.text = "Yasir Fayrooz";
        }
        else if (Text.text == "Yasir Fayrooz")
        {
            Text.text = "Nicholas Bader";
        }
        else if(Text.text == "Nicholas Bader")
        {
            Text.text = "Reece Karslake";
        }
        else if (Text.text == "Reece Karslake")
        {
            Text.text = "Xuan Trieu Manh";
        }
        else if (Text.text == "Xuan Trieu Manh")
        {
            Text.text = "Victor Abolarin";
        }
        else if (Text.text == "Victor Abolarin")
        {
            Text.text = "Chong Zhang";
        }
        else if (Text.text == "Chong Zhang")
        {
            Text.text = "Martin Ma";
        }
        else if (Text.text == "Martin Ma")
        {
            Text.text = "Alexander Baldwin";
        }


        //Roles
        if (Text.text == "Project Supervisor")
        {
            Text.text = "Lead Programmer Animator";
        }
        else if (Text.text == "Lead Programmer Animator")
        {
            Text.text = "Lead Artist + Animator + Sounds";
        }
        else if (Text.text == "Lead Artist + Animator + Sounds")
        {
            Text.text = "UI Designer Programmer Animator";
            Text.fontSize = 15;
        }
        else if (Text.text == "UI Designer Programmer Animator")
        {
            Text.text = "Audio Engineer";
            Text.fontSize = 18;
        }
        else if (Text.text == "Audio Engineer")
        {
            Text.text = "Audio Engineer 2";
        }
        else if (Text.text == "Audio Engineer 2")
        {
            Text.text = "Bug testers, Surveyers, HR";
        }
        else if (Text.text == "Bug testers, Surveyers, HR")
        {
            Text.text = "Bug testers, Surveyers, HR 2";
        }
        else if (Text.text == "Bug testers, Surveyers, HR 2")
        {
            Text.text = "Project Supervisor";
        }
    }
}
