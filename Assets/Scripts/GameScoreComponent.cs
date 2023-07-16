using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreComponent : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int playerScore;
    [SerializeField] Grid grid;
    [SerializeField] int playersUpmostTouchedGrid;
    [SerializeField] int playersGrid;

    private void Start()
    {
        playerScore = 0;
        playersUpmostTouchedGrid = grid.WorldToCell(player.transform.position).y;
        
    }

    // Update is called once per frame
    void Update()
    {
        playersGrid = grid.WorldToCell(player.transform.position).y;
        UpdateLastTouchedGrid();
      
    }
    public void UpdateGameScore()
    {
        if(grid.WorldToCell(player.transform.position).y+1 > playersUpmostTouchedGrid) 
        {
            playerScore++;
        }
    }
    public void UpdateLastTouchedGrid()
    {
        if(grid.WorldToCell(player.transform.position).y >= playersUpmostTouchedGrid)
        {
            playersUpmostTouchedGrid = grid.WorldToCell(player.transform.position).y;
        }
    }
}
