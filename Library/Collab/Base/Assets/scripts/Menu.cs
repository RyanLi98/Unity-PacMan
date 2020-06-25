﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void NextLevel() // function to advance to next level scene when press button in menu
    {
        int cars = gameObject.GetComponent<PacmanCollision>().count;

        string s = SceneManager.GetActiveScene().name;
        if(s == "_kaimuki"){
            if(cars > 317)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(s == "_McCullyPac"){
            if (cars > 150)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if( s == "chinatown PACMAC"){
            if ( cars > 241)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void RestartLevel() // function to restart level; reload level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartGame() // function to restart entire game; go to main menu
    {
        SceneManager.LoadScene(0);
        string s = SceneManager.GetActiveScene().name;

    }

}

