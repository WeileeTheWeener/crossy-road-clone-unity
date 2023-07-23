using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreComponent : MonoBehaviour
{
    [SerializeField] GameObject player;
    private int playerScore;
    private int highScore;
    private Grid grid;
    [SerializeField] int playersUpmostTouchedGrid;
    [SerializeField] int playersGrid;

    public int PlayerScore { get => playerScore; set => playerScore = value; }
    public int HighScore { get => highScore; set => highScore = value; }

    private void Start()
    {   
        grid = GridComponent.GetGrid();
        playerScore = 0;
        playersUpmostTouchedGrid = grid.WorldToCell(player.transform.position).y;
        HighScore = PlayerPrefs.GetInt("playerHighScore");
        
    }
    // Update is called once per frame
    void Update()
    {
        playersGrid = player.GetComponent<PlayerMovementComponent>().GridIndex.y;
        //UpdateLastTouchedGrid(); 
    }
    public void UpdateGameScore()
    {
        if(grid.WorldToCell(player.transform.position).y > playersUpmostTouchedGrid-1) 
        {
            playerScore++;
        }
    }
    public void UpdateLastTouchedGrid()
    {
       
        if(playersGrid+1 > playersUpmostTouchedGrid)
        {
            playersUpmostTouchedGrid++;
        }
    }
    public void ResetUpmostTouchedGrid()
    {
        playersUpmostTouchedGrid = -2; 
    }
    public void ResetGameScore()
    {    
        playerScore = 0;    
    }
    public void UpdateHighScore()
    {
        if(playerScore > HighScore)
        {
            HighScore = playerScore;
        }

    }
}
