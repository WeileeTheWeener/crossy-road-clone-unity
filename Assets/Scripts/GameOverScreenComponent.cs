using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreenComponent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameScoreComponent gameScoreComponent;

    private void OnEnable()
    {
        gameScoreText.text = string.Format("Score:{0}", gameScoreComponent.PlayerScore);
        highScoreText.text = string.Format("High Score:{0}", gameScoreComponent.HighScore);
    }

}
