using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    List<HighScoreElements> highscoreList = new List<HighScoreElements>();
    [SerializeField] int maxCount = 5;
    [SerializeField] string filename;

    private void Start()
    {
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highscoreList = FileController.ReadListFromJSON<HighScoreElements>(filename);

        while(highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }

    }
    private void SaveHighscore()
    {
        FileController.SaveToJSON<HighScoreElements>(highscoreList, filename);
    }

    public void AddHighscoreIfPossible(HighScoreElements element)
    {
        for(int i = 0; i < maxCount; i ++)
        {
            if(i > highscoreList.Count || element.points > highscoreList[i].points)
            {
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }
                SaveHighscore();
                break;
            }
        }
    }































    //int highscore;

    //public int Highscore
    //{
    //    set
    //    {
    //        highscore = value;
    //        highScoreUI.SetHighscore(value);
    //    }
    //}

    //private void Start()
    //{
    //    SetLatestHighscore();
    //}

    //private void SetLatestHighscore()
    //{
    //    Highscore = PlayerPrefs.GetInt("HighScore", 0);
        
    //}

    //private void SaveHighScore(int score)
    //{
    //    PlayerPrefs.SetInt("HighScore", score);
    //}

    //public void SetHighScoreIfGreater(int score)
    //{
    //    if(score >highscore)
    //    {
    //        Highscore = score;
    //        SaveHighScore(score);
            
    //    }
    //}
}
