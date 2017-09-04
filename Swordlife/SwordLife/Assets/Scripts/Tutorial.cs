using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour{

    public Text Text;
    public Text subText;

    private Transform Movement;
    private Rigidbody2D Drone3RigidBody;
    private Rigidbody2D Drone4RigidBody;

    //enemies
    public GameObject Drone1;
    public GameObject Drone2;
    public GameObject Drone3;
    public GameObject Drone4;
    public GameObject Saw;
    public GameObject Laser;

    //UI
    public GameObject Player;
    public GameObject HealthBar;
    public GameObject ScoreUI;
    public GameObject LevelUI;
    public GameObject ActiveText;

    void Start()
    {
        Movement = GameObject.FindGameObjectWithTag("Welcome").GetComponent<Transform>();
        Drone3RigidBody = Drone3.GetComponent<Rigidbody2D>();
        Drone4RigidBody = Drone4.GetComponent<Rigidbody2D>();
        Words();
    }

    void Update()
    {
        if (Drone3RigidBody.velocity.x > 1)
        {
            WhileLoop();
        }
    }

    private void Words()
    {
        Text.text = "Welcome to SwordLife!";
        subText.text = "Press next to continue...";
        subText.fontSize = 10;
    }

    public void Next()
    {
        if(Text.text == "Welcome to SwordLife!")
        {
            Movement.position = new Vector3(0, -40);
            Text.text = "This is your player";
        }
        else if(Text.text == "This is your player")
        {
            Movement.position = new Vector3(0, 0);
            Text.text = "There are 3 different enemies in the game";
        }
        else if (Text.text == "There are 3 different enemies in the game")
        {
            Movement.position = new Vector3(0, 0);
            Text.text = "All enemies come from either side of the screen";
        }
        else if (Text.text == "All enemies come from either side of the screen")
        {
            Movement.position = new Vector3(0, 0);
            Drone1.SetActive(true);
            Drone2.SetActive(true);
            Text.text = "The Drone requires you to swipe left or right to swing your sword and kill";
        }
        else if (Text.text == "The Drone requires you to swipe left or right to swing your sword and kill")
        {
            Movement.position = new Vector3(0, 0);
            Drone1.SetActive(false);
            Drone2.SetActive(false);
            Saw.SetActive(true);
            Text.text = "The Saw requires you to swipe up to dodge";
        }
        else if (Text.text == "The Saw requires you to swipe up to dodge")
        {
            Movement.position = new Vector3(0, 0);
            Saw.SetActive(false);
            Laser.SetActive(true);
            Text.text = "The Laser requires you to swipe down to dodge the laser shot";
        }
        else if (Text.text == "The Laser requires you to swipe down to dodge the laser shot")
        {
            Movement.position = new Vector3(0, 150);
            Laser.SetActive(false);
            HealthBar.SetActive(true);
            Text.text = "You have 3 lives in each game";
        }
        else if (Text.text == "You have 3 lives in each game")
        {
            Movement.position = new Vector3(-200, 130);
            HealthBar.SetActive(false);
            ScoreUI.SetActive(true);
            Text.text = "This is your score bar. Try and get the best highscore possible!";
        }
        else if (Text.text == "This is your score bar. Try and get the best highscore possible!")
        {
            Movement.position = new Vector3(-200, 70);
            ScoreUI.SetActive(false);
            LevelUI.SetActive(true);
            Text.text = "This is your Level bar. Every 5 points, your level increases and so does the enemy speeds!";
        }
        else if (Text.text == "This is your Level bar. Every 5 points, your level increases and so does the enemy speeds!")
        {
            Movement.position = new Vector3(-200, 70);
            ActiveText.SetActive(false);
            LevelUI.SetActive(false);
            
            WhileLoop();
        }
        else if (Text.text == "Good Job!")
        {
            Movement.position = new Vector3(0, -60);
            ActiveText.SetActive(false);
            WhileLoop();
        }
    }

    private void WhileLoop()
    {
        float dist = Vector3.Distance(Drone3.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
        Drone3RigidBody.velocity = Vector2.right * 200;
        if (dist < 165)
          {
             Time.timeScale = 0;
             Movement.position = new Vector3(0, -60);
             Text.text = "Swipe left to destroy the Drone!";
             ActiveText.SetActive(true);

            if (Controls.swipeDirection == Swipe.Left)
            {
               Time.timeScale = 1;
               GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Attack_Animation");
               Text.text = "Good Job!";
               Drone3RigidBody.velocity = Vector2.right * 0;
            }
         }

        if (Text.text == "Good Job!")
        {
            Drone4.SetActive(true);
            float dist2 = Vector3.Distance(Drone4.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
            Drone4RigidBody.velocity = Vector2.left * 200;
        }

    }


}
