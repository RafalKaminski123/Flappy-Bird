using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseView
{
    [SerializeField] private TextMeshProUGUI newHighScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button scoreBoardButton;
    public Button ScoreBoardButton => scoreBoardButton;

    public override void ShowView()
    {
        base.ShowView();
        backToMenuButton.onClick.AddListener(ReloadingUtils.ToMenu);
        tryAgainButton.onClick.AddListener(ReloadingUtils.TryAgain);
    }

    public override void HideView()
    {
        base.HideView();
        backToMenuButton.onClick.RemoveAllListeners();
        tryAgainButton.onClick.RemoveAllListeners();
    }

    public void UpdateScore(int score, bool isNewHighScore)
    {
        this.scoreText.text = score.ToString();
        if(isNewHighScore)
            newHighScoreText.gameObject.SetActive(true);
    }
}
