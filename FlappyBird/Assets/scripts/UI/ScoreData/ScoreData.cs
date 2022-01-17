using System;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public string highscore;
    public string gameOne;
    
    [HideInInspector]
    public int points;

    public ScoreData(string highscore, string game, int points)
    {
        this.highscore = highscore;
        gameOne = game;
        this.points = points;
    }
}
