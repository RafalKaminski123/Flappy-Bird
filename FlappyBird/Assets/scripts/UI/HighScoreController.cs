using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public List<HighScoreElements> highscoreList = new List<HighScoreElements>();
    [SerializeField] int maxCount = 5;
    [SerializeField] string filename;

    private void Start()
    {
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highscoreList = FileController.ReadListFromJSON<HighScoreElements>(filename);

        while (highscoreList.Count > maxCount)
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
        if (highscoreList.Count > 0)
        {
            for (int i = 0; i < maxCount; i++)
            {
                if (i >= highscoreList.Count)
                {
                    highscoreList.Add(element);
                    break;
                }

                if (element.points > highscoreList[i].points)
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
        else
        {
            highscoreList.Add(element);
            SaveHighscore();
        }
    }
}
