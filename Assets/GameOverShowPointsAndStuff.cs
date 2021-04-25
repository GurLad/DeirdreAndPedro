using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverShowPointsAndStuff : MonoBehaviour
{
    public Text Points;
    public Text Score;
    public Text HighScore;
    public void Init(int score)
    {
        Score.text = "Score: " + score;
        Points.text = "Points: " + PlayerPrefs.GetInt("Points");
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        gameObject.SetActive(true);
    }
}
