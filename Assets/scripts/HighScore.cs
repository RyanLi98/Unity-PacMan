using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{

    static public int score = 0;
  public Text scoreText;
    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
    void Update()
    {
        scoreText.text = "High Score:" + score.ToString();
        if (score > PlayerPrefs.GetInt("HighSCore"))
        {
            PlayerPrefs.SetInt("HighSCore", score);
        }
    }
}