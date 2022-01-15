using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] HighScoreUI highScoreUI;

    int highscore;

    public int Highscore
    {
        set
        {
            highscore = value;
            highScoreUI.SetHighscore(value);
        }
    }

    private void Start()
    {
        SetLatestHighscore();
    }

    private void SetLatestHighscore()
    {
        Highscore = PlayerPrefs.GetInt("HighScore", 0);
        
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void SetHighScoreIfGreater(int score)
    {
        if(score >highscore)
        {
            Highscore = score;
            SaveHighScore(score);
            
        }
    }
}
