using System;

[Serializable]
public class HighScoreElements
{
    public string gameOne;
    public int points;

    public HighScoreElements(string game, int points)
    {
        gameOne = game;
        this.points = points;
    }
}
