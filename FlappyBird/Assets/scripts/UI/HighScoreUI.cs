using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    private void UpdateUI(List<HighScoreElements> list)
    {
        for( int i = 0; i < list.Count; i++)
        {
            HighScoreElements element = list[i];

            if(element.points > 0)
            {
                if(i >= uiElements.Count)
                {
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);
                    uiElements.Add(inst);
                }

                var texts = uiElements[i].GetComponentsInChildren<Text>();
            }
        }
    }
}
