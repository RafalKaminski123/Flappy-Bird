using System.Collections.Generic;
using UnityEngine;

public class HighScoreSavingSystem : MonoBehaviour
{
    private List<ScoreData> highScoreLoadedList = new List<ScoreData>();
    public List<ScoreData> HighScoreList => highScoreLoadedList;
    
    [SerializeField] int maxCount = 5;
    [SerializeField] string filename;

    private bool isHighest;

    public bool IsHighest => isHighest;

    private void Start()
    {
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highScoreLoadedList = FileController.ReadListFromJSON<ScoreData>(filename);

        while (highScoreLoadedList.Count > maxCount)
        {
            highScoreLoadedList.RemoveAt(maxCount);
        }

    }
    private void SaveHighscore()
    {
        FileController.SaveToJSON<ScoreData>(highScoreLoadedList, filename);
    }

    public void AddHighscoreIfPossible(ScoreData data)
    {
        if (highScoreLoadedList.Count > 0)
        {
            for (int i = 0; i < maxCount; i++)
            {
                if (i >= highScoreLoadedList.Count)
                {
                    highScoreLoadedList.Add(data);
                    break;
                }

                if (data.points > highScoreLoadedList[i].points)
                {
                    highScoreLoadedList.Insert(i, data);

                    while (highScoreLoadedList.Count > maxCount)
                    {
                        highScoreLoadedList.RemoveAt(maxCount);
                    }
                    SaveHighscore();
                    if (i == 0)
                        isHighest = true;
                    break;
                }
            }
        }
        else
        {
            highScoreLoadedList.Add(data);
            SaveHighscore();
            isHighest = true;
        }
    }
}
