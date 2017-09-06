using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour{

    public Text Text;
    public Text subText;

    private Transform Movement;
    public Transform ButtonMovement;
    public GameObject SubText;
    public GameObject PlayButton;
    private float PlayerScale;

    private Rigidbody2D Drone3RigidBody;
    private Rigidbody2D Drone4RigidBody;
    private Rigidbody2D Saw2RigidBody;

    //enemies
    public GameObject Drone1;
    public GameObject Drone2;
    public GameObject Drone3;
    public GameObject Drone4;
    public GameObject Saw;
    public GameObject Saw2;
    public GameObject Laser;
    public GameObject Laser2;
    public GameObject Laser2shot;

    //UI
    public GameObject Player;
    public GameObject HealthBar;
    public GameObject ScoreUI;
    public GameObject LevelUI;
    public GameObject ActiveText;

    public GameObject ArrowLeft;

    private bool Laser2Bool = false;

    void Start()
    {
        Movement = GameObject.FindGameObjectWithTag("Welcome").GetComponent<Transform>();
        PlayerScale = Player.transform.localScale.x;
        Drone3RigidBody = Drone3.GetComponent<Rigidbody2D>();
        Drone4RigidBody = Drone4.GetComponent<Rigidbody2D>();
        Saw2RigidBody = Saw2.GetComponent<Rigidbody2D>();
        Words();
    }

    void Update()
    {
        if (Drone3.activeInHierarchy || Drone4.activeInHierarchy || Saw2.activeInHierarchy || Laser2Bool)
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
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        if(Text.text == "Welcome to SwordLife!")
        {
            Movement.position = new Vector3(0, -38);
            ButtonMovement.position = new Vector3(0, -78);
            Text.text = "This is your player";
        }
        else if(Text.text == "This is your player")
        {
            Movement.position = new Vector3(0, 0);
            ButtonMovement.position = new Vector3(0, -70);
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
            ButtonMovement.position = new Vector3(-200, -40);
            ScoreUI.SetActive(false);
            LevelUI.SetActive(true);
            Text.text = "This is your Level bar. Every 5 points, your level increases and so does the enemy speeds!";
        }
        else if (Text.text == "This is your Level bar. Every 5 points, your level increases and so does the enemy speeds!")
        {
            Movement.position = new Vector3(-200, 70);
            ActiveText.SetActive(false);
            LevelUI.SetActive(false);
            ButtonMovement.gameObject.SetActive(false);
            SubText.SetActive(false);
            Movement.position = new Vector3(0, -60);
            WhileLoop();
        }
    }

    private void WhileLoop()
    {
        float dist = Vector3.Distance(Drone3.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
        float dist2 = Vector3.Distance(Drone4.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
        float dist3 = Vector3.Distance(Saw2.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
        float dist4 = Vector3.Distance(Laser2shot.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);
        if (Text.text == "This is your Level bar. Every 5 points, your level increases and so does the enemy speeds!")
        {
            Drone3.SetActive(true);
            Drone3RigidBody.velocity = Vector2.right * 200;
        }

        if (Text.text == "Swipe right to destroy the Drone!" || Text.text == "Swipe left to destroy the Drone!" || Text.text == "Swipe up to dodge the Drone!" || Text.text == "Swipe down to dodge the Laser shot!")
        {
            ActiveText.SetActive(true);
            Time.timeScale = 0;
        } else if(Text.text == "Good Job!" || Text.text == "Nice work!" || Text.text == "Awesome!")
        {
            Time.timeScale = 1;
        }
        //Laser
        if (Laser2Bool)
        {
            if (Laser2shot.activeInHierarchy)
            {
                Laser2shot.GetComponent<Rigidbody2D>().velocity = Vector2.left * 400;
            }
            if (Text.text == "Nice work!" || Text.text == "Swipe down to dodge the Laser shot!")
            {
                if (dist4 < 80)
                {
                    Movement.position = new Vector3(0, -50);
                    Text.text = "Swipe down to dodge the Laser shot!";
                    ArrowLeft.SetActive(true);
                    ArrowLeft.GetComponent<Animator>().Play("ArrowDownAnim");
                    if (Controls.swipeDirection == Swipe.Down)
                    {
                        FindObjectOfType<AudioManager>().Play("TutorialPlus");
                        ArrowLeft.SetActive(false);
                        Movement.position = new Vector3(0, 0);
                        Text.text = "Awesome!";
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Duck_Animation 1");
                    }
                }
            }
            if (dist4 > 200 && Text.text == "Awesome!")
            {
                Laser2shot.SetActive(false);

                Movement.position = new Vector3(0, 100);
                Text.text = "You are all set now, press play to get right in the game. Good luck!";
                PlayButton.SetActive(true);
            }
        }
        //Saw
        if (Saw2.activeInHierarchy)
        {
            if (Text.text != "Nice work!")
            {
                Saw2RigidBody.velocity = Vector2.right * 300;

                if (dist3 < 160)
                {
                    Movement.position = new Vector3(0, -50);
                    Text.text = "Swipe up to dodge the Drone!";
                    ArrowLeft.SetActive(true);
                    ArrowLeft.GetComponent<Animator>().Play("ArrowUpAnim");
                    if (Controls.swipeDirection == Swipe.Up)
                    {
                        FindObjectOfType<AudioManager>().Play("TutorialPlus");
                        ArrowLeft.SetActive(false);
                        Movement.position = new Vector3(0, 0);
                        Text.text = "Nice work!";
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Jump_Animation 1");
                    }
                }
            }
            if (dist3 > 200 && Text.text == "Nice work!")
            {
                Saw2RigidBody.velocity = Vector2.right * 0;
                Saw2.SetActive(false);
                Laser2Bool = true;
                Laser2.SetActive(true);
            }
        }
        //Drone4
        if (Drone4.activeInHierarchy && !Saw2.activeInHierarchy)
        {
            Drone4RigidBody.velocity = Vector2.left * 200;
            if (dist2 < 165)
            {
                Movement.position = new Vector3(0, -50);
                Text.text = "Swipe right to destroy the Drone!";
                ArrowLeft.SetActive(true);
                ArrowLeft.GetComponent<Animator>().Play("ArrowRightAnim");
                if (Controls.swipeDirection == Swipe.Right)
                {
                    FindObjectOfType<AudioManager>().Play("TutorialPlus");
                    ArrowLeft.SetActive(false);
                    Player.transform.localScale = new Vector3(-PlayerScale, 15);
                    Drone4RigidBody.velocity = Vector2.left * 0;
                    Movement.position = new Vector3(0, 0);
                    Text.text = "Good Job!";
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Attack_Animation 1");
                    Saw2.SetActive(true);
                }
            }
        }
        //Drone3
        if (dist < 165 && Drone3.activeInHierarchy && !Drone4.activeInHierarchy)
          {
            Movement.position = new Vector3(0, -50);
            Text.text = "Swipe left to destroy the Drone!";
            ArrowLeft.SetActive(true);
            if (Controls.swipeDirection == Swipe.Left)
            {
                FindObjectOfType<AudioManager>().Play("TutorialPlus");
                ArrowLeft.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Attack_Animation 1");
                Text.text = "Good Job!";
                Movement.position = new Vector3(0, 0);
                Drone4.SetActive(true);
                Drone3RigidBody.velocity = Vector2.right * 0;
            }
          }
    }


    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        SceneManager.LoadScene(1);
        LaserShot.movementSpeed = 400;
        DroneScript.movementSpeed = 250;
        SawScript.movementSpeed = 400;
    }

}
