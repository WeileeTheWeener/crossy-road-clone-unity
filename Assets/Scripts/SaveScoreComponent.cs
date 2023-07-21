using UnityEditor;
using UnityEngine;

public class SaveScoreComponent : MonoBehaviour
{
    [SerializeField] GameScoreComponent gameScoreComponent;
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("playerHighScore", gameScoreComponent.highScore); //save to playerprefs
        PlayerPrefs.Save();
    }
}
