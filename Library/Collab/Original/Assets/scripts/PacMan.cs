using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacMan: MonoBehaviour
{

    public float distance0;
    public float distance1;
    public float distance2;
    public float speed;
    public Color defaultColor;
    public Color powerUpColor;
    private float staticSpeed;
    private Rigidbody2D rb2d;

    private int count;
    private int score;
    public int health;
    public int powerUpTimer;
    int dirX = 0, dirY = 0;

    public Text winText;
    public Text countText;
 

    public GameObject Player;
    public GameObject Ghost0;
    public GameObject Ghost1;
    public GameObject Ghost2;
    public GameObject Paclife1, Paclife2, Paclife3, Paclife4, Paclife5;
    public GameObject[] PacLife;
   
    public bool poweredUp;

    void Start()
    {
        health = 3;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        // winText.text = "";
        // SetCountText();
        Paclife4.gameObject.SetActive(false);
        Paclife5.gameObject.SetActive(false);
        Player.GetComponent<Renderer>().material.color = defaultColor;

    }
   void Update()
    {
        PacMove();
        //This is for animation movement
        GetComponent<Animator>().SetFloat("MovX", dirX);
        GetComponent<Animator>().SetFloat("MovY", dirY);
      //  Debug.Log(score);

    }
    void FixedUpdate()
    {
        if (poweredUp)
        {
            powerUpTimer++;
            if (powerUpTimer == 300)
                PowerUp();

        }
        distance0 = Vector3.Distance(Player.transform.position, Ghost0.transform.position);
        distance1 = Vector3.Distance(Player.transform.position, Ghost1.transform.position);
        distance2 = Vector3.Distance(Player.transform.position, Ghost2.transform.position);
        if (distance0 < 1 || distance1 < 1 || distance2 < 1 && poweredUp == false) // pacman and any ghost(s) touch without powerup
        {
            Player.SetActive(false); // pacman dies

            // to minus health when ghosts dies
            // bad logic
            health -= 1;
            //Debug.Log("health equals:" + health);
            //here the ifs removes pac life on side of screen
            if (health == 2)
            {
                PacLife[health].SetActive(false);
            }
            //goes back to start scene and location
            //SceneManager.LoadScene("_Kaimuki");
            if(health == 1)
            {
                PacLife[health].gameObject.SetActive(false);
            }
            if (health == 0)
            {
                PacLife[health].gameObject.SetActive(false);
            }
        } else if (distance0 < 1 && poweredUp == true) // pacman and ghost0 touches with powerup
        {
            Ghost0.SetActive(false);
        } else if (distance1 < 1 && poweredUp == true) // pacman and ghost1 touches with powerup
        {
            Ghost1.SetActive(false);
        } else if (distance2 < 1 && poweredUp == true) // pacman and ghost2 touches with powerup
        {
            Ghost2.SetActive(false); 
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
            score += 500;
            staticSpeed = speed;
            speed = speed * 2;
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
