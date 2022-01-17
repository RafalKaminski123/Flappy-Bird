using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI bombText;

    public void UpdateUIInfo(int points, int bombs)
    {
        pointsText.text = points.ToString();
        bombText.text = bombs.ToString();
    }
}
