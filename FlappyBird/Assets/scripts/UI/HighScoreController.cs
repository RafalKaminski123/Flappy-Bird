using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    

    int highscore;

    private void Start()
    {
        SetLatestHighscore();
    }

    private void SetLatestHighscore()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void SetHighScoreIfGreater(int score)
    {
        if(score >highscore)
        {
            highscore = score;
            SaveHighScore(score);
        }
    }
}
