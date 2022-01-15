using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] PointsCounter pointCounter;
    [SerializeField] PointHUD pointHUD;
    bool gameStop = false;




    //void Start()
    //{
    //    StartCoroutine(CountPoints());
    //}
    //public void StopGame()
    //{
    //    gameStop = true;
    //}

    //private IEnumerator CountPoints()
    //{
    //    while (true)
    //    {
    //        pointHUD.Score += 1;
    //        yield return new WaitForSeconds(1);


    //    }

    //}

}
