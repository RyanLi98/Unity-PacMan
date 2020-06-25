using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    int count = 0;
    bool Hit = false;
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


    }
    //How AI moves
    private Vector2 AILogic()
    {
        //Random direction generator
        float Dir = Random.Range(0, 9);
        count++;

        //Moves in a direction for 20 FixedUpdates
        while (count == 20)
        {
            //Chooses the direction of the movement based on RDG(random direction generator)
            Hold = Dir < 4 ? Dir < 2 ? new Vector2(speed, 0) : new Vector2(-speed, 0)
                : Dir > 7 ? new Vector2(0, speed) : new Vector2(0, -speed);
            count = 0;
            rb2d.velocity = Hold;
        }
        if (Hit)
        {
            Hold = Dir < 4 ? Dir < 2 ? new Vector2(speed, 0) : new Vector2(-speed, 0)
                : Dir > 7 ? new Vector2(0, speed) : new Vector2(0, -speed);
            Hit = false;
        }
        return Hold;

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        //If the AI collides with the walls, it changes direction
        if (collidedWith.CompareTag("Background"))
        {
            Hit = true;
            AILogic();
            Debug.Log("AI");
        }

    }
}
