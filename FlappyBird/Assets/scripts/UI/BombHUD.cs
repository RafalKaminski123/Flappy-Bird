using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombHUD : MonoBehaviour
{
    [SerializeField] Text bombValue;

    int bomb = 0;
    public PointHUD pointHUD;

    private void Awake()
    {
        UpdateBombHUD();
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
            UpdateBombHUD();
        }

    }

    public void UpdateBombHUD()
    {

        if (pointHUD.Score % 10 == 0)
        {
            bomb++;
            Debug.Log("Booooms");
            if (bomb < 3)
            {
                bomb--;
                
                bombValue.text = bomb.ToString();
            }
        }

    }
}
