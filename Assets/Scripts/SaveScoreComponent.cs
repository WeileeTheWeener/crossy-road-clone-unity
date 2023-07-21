using UnityEditor;
using UnityEngine;

public class SaveScoreComponent : MonoBehaviour
{
    [SerializeField] ScoreScriptableObject ScoreScriptableObject;
    [SerializeField] GameScoreComponent gameScoreComponent;

    private void Start()
    {
        #if UNITY_EDITOR
            EditorApplication.quitting += SaveHighScore;
        #endif

    }
    public void SaveHighScore()
    {
        ScoreScriptableObject.highScore = gameScoreComponent.highScore;
    }
    private void OnApplicationQuit()
    {
        //SaveHighScore();
    }
}
