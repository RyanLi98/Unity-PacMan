using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanCollision : MonoBehaviour {

    public int count = 0;
    public int cars = 0;

    // Use this for initialization
    void Start () {
        count = 300;
	}
	
	// Update is called once per frame
	void Update () {
        count = 320;

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        //Switch statements for the different types of pickups
        GameObject GO = other.gameObject;
        string s = other.gameObject.tag;
        switch(s){
        case "Fruit":
           GO.SetActive(false);
           HighScore.score += 1000;
           break;
        case "PacCar":
           GO.SetActive(false);
           cars++;
           HighScore.score += 100;
           break;
        case "PowerCar": //This is the powerup dot from pacman
           GO.SetActive(false);
           PacMan PM = gameObject.GetComponent<PacMan>();
           PM.PowerUp();
           HighScore.score += 500; 
           break;
        default:
           break;
        }
        count = HighScore.score % 100;
    }
}
