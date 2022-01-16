using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHUD : MonoBehaviour
{
    [SerializeField] Text scoreCount;
    [SerializeField] Text endScore;

    int score = -1;
    


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

    public void UpdateHUD()
    {
        score++;
        scoreCount.text = score.ToString();
        endScore.text = score.ToString();


        //if (score % 10 == 0)
        //{
        //    if (bombCounter < 3)
        //    {
        //        bombCounter++;
        //    }
        //}

    }

}
