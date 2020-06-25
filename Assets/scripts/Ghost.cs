using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    int count = 0;
    int dirX = 0, dirY= 0;
    Vector2 Hold = new Vector2();
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = AILogic();
    }

    // Update is called once per frame
    void Update()
    {

        rb2d.velocity = AILogic();
        GetComponent<Animator>().SetFloat("MovX", dirX);
        GetComponent<Animator>().SetFloat("MovY", dirY);

    }
    //How AI moves
    private Vector2 AILogic()
    {
        //Random direction generator
        float Dir = Random.Range(0, 9);
        count++;
        
        //Moves in a direction for 20 FixedUpdates
        while (count == 40)
        {
            dirY = 0; dirX = 0;
            //Chooses the direction of the movement based on RDG(random direction generator)
            Hold = Dir < 5 ? Dir < 3 ? new Vector2(speed, 0) : new Vector2(-speed, 0)
                : Dir > 7 ? new Vector2(0, speed) : new Vector2(0, -speed);
            count = 0;
            rb2d.velocity = Hold;
            if(Dir < 5)
            {
                dirX = -1;
                if(Dir < 3)
                    dirX = 1;
            }
            if(Dir > 5)
            {
                dirY = -1;
                if (Dir > 7)
                    dirY = 1;
            }

        }
        return Hold;
    }
}
