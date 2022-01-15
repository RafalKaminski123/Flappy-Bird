using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public GameObject toMenu;
    public GameObject tryAgain;

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
