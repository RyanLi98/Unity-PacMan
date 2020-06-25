using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacMan: MonoBehaviour
{

    public float distance0;
    public float distance1;
    public float distance2;
    public float distance3;
    public float speed;
    public Color defaultColor;
    public Color powerUpColor;
    private float staticSpeed;
    private Rigidbody2D rb2d;

    private int count;
    public int health = 3; // pacman has 3 lifes, maximum amount of lives is 5
    public int powerUpTimer;
    public int respawnTimer;
    int dirX = 0, dirY = 0;

    public Text winText;
    public Text countText;
    public GameObject Player;
    public GameObject Ghost0, Ghost1, Ghost2, Ghost3; // Ghost0-2 are NPC and Ghost3 is player 2
    public GameObject[] PacLife;
    public GameObject RespawnTracker; // object to activate PacMan once it is deactivated because Pacman died
   
    public bool poweredUp;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        // winText.text = "";
        // SetCountText();
        Player.GetComponent<Renderer>().material.color = defaultColor;
        PacLife = GameObject.FindGameObjectsWithTag("Paclife");
        staticSpeed = speed;
    }
   void Update()
    {
        PacMove();
        //This is for animation movement
        GetComponent<Animator>().SetFloat("MovX", dirX);
        GetComponent<Animator>().SetFloat("MovY", dirY);
    }
    void FixedUpdate()
    {
    
        // We used distance to decide collision for pacman-ghost because coll/istrigger functions does not work in this case
        distance0 = Vector3.Distance(Player.transform.position, Ghost0.transform.position);
        distance1 = Vector3.Distance(Player.transform.position, Ghost1.transform.position);
        distance2 = Vector3.Distance(Player.transform.position, Ghost2.transform.position);
        distance3 = Vector3.Distance(Player.transform.position, Ghost3.transform.position);     // player2 distance
        if (distance0 < 2 || distance1 < 2 || distance2 < 2 || distance3 < 2 && poweredUp == false) // pacman and any ghost(s) touch without powerup
        {
            Player.SetActive(false);
            Debug.Log("Test");
            if (health > 0)
            {
                RespawnTracker.SetActive(true); // start respawn tracker
            }
            health -= 1;
            PacLife[health].gameObject.SetActive(false);
           // Player.SetActive(false);// pacman dies
        } else if (distance0 < 2 && poweredUp == true) // pacman and ghost0 touches with powerup
        {
            Ghost0.SetActive(false);
        } else if (distance1 < 2 && poweredUp == true) // pacman and ghost1 touches with powerup
        {
            Ghost1.SetActive(false);
        } else if (distance2 < 2 && poweredUp == true) // pacman and ghost2 touches with powerup
        {
            Ghost2.SetActive(false); 
        } else if (distance3 < 2 && poweredUp == true) // pacman and ghost2 touches with powerup
        {
            Ghost3.SetActive(false);
        }
        if (poweredUp)
        {
            powerUpTimer++;
            if (powerUpTimer == 300)
                PowerUp();
        }

    }
    void PacMove()
    {
        //Ints for direction
        bool moveKeyPressedX = false;
        bool moveKeyPressedY = false;

        //Arrow key for movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            moveKeyPressedX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            moveKeyPressedX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dirY = 1;
            moveKeyPressedY = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dirY = -1;
            moveKeyPressedY = true;
        }
        //Sets the velocity of movement based on arrow key pressed
        if (moveKeyPressedX == true)
        {
            rb2d.velocity = new Vector2(dirX * speed, 0);
            dirY = 0;
        }
        if (moveKeyPressedY == true)
        {
            rb2d.velocity = new Vector2(0, dirY * speed);
            dirX = 0;
        }
    }
    public void PowerUp()
    {
        if (powerUpTimer == 300)
        {
            speed = staticSpeed;
            poweredUp = false;
            powerUpTimer = 0;
            Player.GetComponent<Renderer>().material.color = defaultColor;
        }
        else
        {
            speed = staticSpeed * 2;
            poweredUp = true;
            Player.GetComponent<Renderer>().material.color = powerUpColor;
        }
    }
/*
    //  void SetCountText()
{
   //countText.text = "Count: " + count.ToString();
   //if (count >=  4)
   //    winText.text = "You win!";
}
    */
}
