using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacGhost : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    int dirX = 0, dirY = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();	
	}

    // Update is called once per frame
   void Update()
    {
        Move();
        GetComponent<Animator>().SetFloat("MovX", dirX);
        GetComponent<Animator>().SetFloat("MovY", dirY);
    }
    void Move()
    {
      
        bool moveKeyPressedX = false;
        bool moveKeyPressedY = false;

        if (Input.GetKey(KeyCode.D))
        {
            dirX = 1;
            moveKeyPressedX = true;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            dirX = -1;
            moveKeyPressedX = true;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            dirY = 1;
            moveKeyPressedY = true;
        }
        else if(Input.GetKey(KeyCode.S))
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
        else if(moveKeyPressedY == true)
        {
            rb2d.velocity = new Vector2(0, dirY * speed);
            dirX = 0;
        }
    }
}
