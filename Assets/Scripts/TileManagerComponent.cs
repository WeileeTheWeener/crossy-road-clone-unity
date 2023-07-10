using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileManagerComponent : MonoBehaviour
{
    public List<GameObject> tileList;
    public UnityEvent onEndReached;
    public TilesetComponent lastSpawnedTile;
    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        onEndReached.AddListener(SpawnTiles);
        
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
            SpawnTiles();
       }

    
    }

    void SpawnTiles()
    {
        int tileToSpawn = Random.Range(0, tileList.Count);
        GameObject tile = GameObject.Instantiate(tileList[tileToSpawn]);
        TilesetComponent tilesetComponent = tile.GetComponent<TilesetComponent>();
        tile.GetComponentInChildren<CarComponent>().grid = grid;

        if (lastSpawnedTile != null)
        {
            Vector3Int lastSpawnedTilesLastCell = grid.WorldToCell(lastSpawnedTile.LastTile.transform.position);
            Vector3Int tilesetCenterCell = grid.WorldToCell(tilesetComponent.transform.position);

            //tile.transform.position = grid.CellToWorld(new Vector3Int(0,lastSpawnedTilesLastCell.y,0)) + tilesetComponent.Size / 2f * grid.cellSize.y * Vector3.forward;
            //tile.transform.position = grid.CellToWorld(new Vector3Int(0, lastSpawnedTilesLastCell.y, 0)) + grid.CellToWorld(tilesetCenterCell);
            tile.transform.position = grid.CellToWorld(new Vector3Int(0, lastSpawnedTilesLastCell.y, 0))+ (float)grid.cellSize.z/2f * Vector3.forward;
            tile.transform.position += (float)tilesetComponent.Size / 2f * Vector3.forward * grid.cellSize.z;
 
        }
        else
        {
            tile.transform.position = grid.CellToWorld(new Vector3Int(0,0,0));
        }
        
        lastSpawnedTile = tilesetComponent;

    }
}
