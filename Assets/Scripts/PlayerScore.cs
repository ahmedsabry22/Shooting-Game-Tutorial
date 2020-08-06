using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text currentScore_TXT;
    public Text highScore_TXT;

    private int currentScore;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore_TXT.text = highScore.ToString();
    }

    public void IncreaseScore()
    {
        currentScore++;
        currentScore_TXT.text = currentScore.ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScore_TXT.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}