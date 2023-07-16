using System;
using TMPro;
using UnityEngine;

public class GameScoreUIComponent : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    [SerializeField] GameScoreComponent gameScoreComponent;
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateGameScoreUI()
    {
        scoreText.text = String.Format("Score: {0}", gameScoreComponent.playerScore.ToString());
    }
}
