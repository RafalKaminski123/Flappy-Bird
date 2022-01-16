using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] PointsCounter pointCounter;
    [SerializeField] HighScoreController highScoreController;
    [SerializeField] PointHUD pointHUD;
    [SerializeField] string gameOne;

    public HighScoreController hsc => highScoreController;

    public void StopGame()
    {
        highScoreController.AddHighscoreIfPossible(new HighScoreElements(gameOne, pointHUD.Score));
        pointCounter.StopGame();
        //highScoreController.SetHighScoreIfGreater(pointHUD.Score);
    }
}