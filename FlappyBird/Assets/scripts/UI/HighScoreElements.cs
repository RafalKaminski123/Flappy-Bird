using System;

[Serializable]
public class HighScoreElements
{
    public string Highscore;
    public string gameOne;
    public int points;

    public HighScoreElements(string highscore ,string game, int points)
    {
        Highscore = highscore;
        gameOne = game;
        this.points = points;
    }
}
