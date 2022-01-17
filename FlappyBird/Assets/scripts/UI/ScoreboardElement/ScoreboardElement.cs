using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardElement : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI orderNumber;
  public TextMeshProUGUI OrderNumber => orderNumber;
  
  [SerializeField] private TextMeshProUGUI playerName;
  public TextMeshProUGUI PlayerName => playerName;
  
  [SerializeField] private TextMeshProUGUI playerScore;
  public TextMeshProUGUI PlayerScore => playerScore;
}
