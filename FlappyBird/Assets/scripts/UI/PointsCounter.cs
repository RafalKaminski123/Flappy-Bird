using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
   
    [SerializeField] PointHUD pointHUD;
    bool gameStop = false;

    public void StopGame()
    {
        gameStop = true;
    }



}
