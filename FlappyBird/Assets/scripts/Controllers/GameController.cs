using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    [SerializeField] private ScoreboardView scoreboardView;
    [SerializeField] private PauseView pauseView;
    [SerializeField] private GameOverView gameOverView;
    [SerializeField] private PointsController pointsController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PipesController pipesController;
    [SerializeField] private HighScoreSavingSystem highScoreSavingSystem;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        pauseView.PlayButton.onClick.AddListener(Play);
        playerController.OnObstacleHitAddListener(GameOver);
        playerController.OnScoreColliderHitAddListener(pointsController.AddPoints);
        gameOverView.ScoreBoardButton.onClick.AddListener(scoreboardView.ShowView);
        Pause();
    }

    private void Update()
    {
        playerController.UpdateController(pointsController, pipesController);
    }

    private void Play()
    {
        pointsController.ResetScoreAndBombs();
        gameOverView.HideView();
        gameView.ShowView();
        Unpause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        playerController.DisableController();
        pauseView.ShowView();
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        playerController.EnableController();
        pauseView.HideView();
    }

    private void GameOver()
    {
        gameView.HideView();
        playerController.DisableController();
        pointsController.StopGame(highScoreSavingSystem);
        Time.timeScale = 0f;
        gameOverView.ShowView();
        gameOverView.UpdateScore(pointsController.Score, highScoreSavingSystem.IsHighest);
        scoreboardView.UpdateBoard(highScoreSavingSystem.HighScoreList);
    }
}