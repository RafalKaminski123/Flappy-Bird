using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardView : BaseView
{
    [SerializeField] private Button backButton;
    
    [SerializeField] 
    private ScoreboardElement highscoreUIElementPrefab;
    
    [SerializeField] 
    private Transform content;
    
    private List<ScoreboardElement> uiElements = new List<ScoreboardElement>();

    private void OnEnable()
    {
        backButton.onClick.AddListener(HideView);
    }

    private void OnDisable()
    {
        backButton.onClick.RemoveAllListeners();
    }

    public void UpdateBoard(List<ScoreData> scoresList)
    {
        for(int i = 0; i < scoresList.Count; i++)
        {
            ScoreData score = scoresList[i];

            if(score.points > 0)
            {
                if(i >= uiElements.Count)
                {
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(content, false);
                    uiElements.Add(inst);
                }

                var uiElement = uiElements[i];
                uiElement.OrderNumber.text = (i+1).ToString();
                uiElement.PlayerName.text = i == 0 ? score.highscore : score.gameOne;
                uiElement.PlayerScore.text = score.points.ToString();
            }
        }
    }
}
