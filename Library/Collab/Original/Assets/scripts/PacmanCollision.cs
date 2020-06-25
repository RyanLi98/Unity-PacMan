using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanCollision : MonoBehaviour {

    public int count;
    public int cars = 0;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        //Switch statements for the different types of pickups
        GameObject GO = other.gameObject;
        string s = other.gameObject.tag;
        switch(s){
        case "Fruit":
           GO.SetActive(false);
        count  =  HighScore.score += 1000;
           break;
        case "PacCar":
           GO.SetActive(false);
           cars++;
         count =  HighScore.score += 100;
           break;
        case "PowerCar": //This is the powerup dot from pacman
           GO.SetActive(false);
           PacMan PM = gameObject.GetComponent<PacMan>();
           PM.PowerUp();
        count  =  HighScore.score += 500; 
           break;
        default:
           break;
        }
        Debug.Log(count);
    }
}
