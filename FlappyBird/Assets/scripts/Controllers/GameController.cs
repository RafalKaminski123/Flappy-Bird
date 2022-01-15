using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    //[SerializeField] PointsCounter pointCounter;
    [SerializeField] HighScoreController highScoreController;
    [SerializeField] PointHUD pointHUD;

    public PlayerController player;
    private int score;
    public GameObject playButton;
    public GameObject gameOver;

    

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        score = 0;
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        PipesController[] pipes = FindObjectsOfType<PipesController>();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
        highScoreController.SetHighScoreIfGreater(pointHUD.Score);
    }


   
}
