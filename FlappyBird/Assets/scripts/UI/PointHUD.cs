using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHUD : MonoBehaviour
{
    [SerializeField] Text scoreCount;
    [SerializeField] Text endScore;
    [SerializeField] Text bombCount;

    int score = -1;
    int bomb = -1;


    private void Awake()
    {
        UpdateHUD();
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            UpdateHUD();
        }

    }

    public int Bomb
    {
        get
        {
            return bomb;
        }

        set
        {
            bomb = value;
            UpdateHUD();
        }

    }

    public void UpdateHUD()
    {
        score++;
        scoreCount.text = score.ToString();
        endScore.text = score.ToString();

        if (Score % 10 == 0)
        {
            
            if (bomb < 3)
            {
                bomb++;
                bombCount.text = bomb.ToString();
            }
        }

    }

}
