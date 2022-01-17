using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private ScoreData scoreDataTemplate;

    private int score;
    private int bombs;
    public int Bombs => bombs;
    public int Score => score;

    [SerializeField] private GameView gameView;

    public void ResetScoreAndBombs()
    {
        score = 0;
        bombs = 0;
    }

    public void AddPoints()
    {
        score++;
        if (score % 10 == 0 && bombs < 3)
        {
            AddBomb();
            return;
        }
        gameView.UpdateUIInfo(score, bombs);
    }

    private void AddBomb()
    {
        bombs++;
        gameView.UpdateUIInfo(score, bombs);
    }

    public void RemoveBomb()
    {
        bombs--;
        gameView.UpdateUIInfo(score, bombs);
    }

    public void StopGame(HighScoreSavingSystem savingSystem)
    {
        savingSystem.AddHighscoreIfPossible(new ScoreData(scoreDataTemplate.highscore, scoreDataTemplate.gameOne, score));
    }
}