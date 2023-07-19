using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreComponent : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int playerScore;
    public int highScore;
    [SerializeField] Grid grid;
    [SerializeField] int playersUpmostTouchedGrid;
    [SerializeField] int playersGrid;

    private void Start()
    {
        
        playerScore = 0;
        playersUpmostTouchedGrid = grid.WorldToCell(player.transform.position).y;
        highScore = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        playersGrid = player.GetComponent<PlayerMovementComponent>().gridIndex.y;
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
        if(playerScore > highScore)
        {
            highScore = playerScore;
        }

    }
}
