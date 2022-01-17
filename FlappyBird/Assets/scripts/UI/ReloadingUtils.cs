using UnityEngine.SceneManagement;

public static class ReloadingUtils
{
    public static void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public static void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
