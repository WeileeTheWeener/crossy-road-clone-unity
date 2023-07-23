using UnityEngine;


public class TileManagerComponent : MonoBehaviour
{
    [SerializeField] TilesetComponent lastSpawnedTile;
    [SerializeField] GameObject cameraDeathZone;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("tile spawned (tilemanager Start func)");
        SpawnTiles();
    }
    public void SpawnTiles()
    {
        GameObject tile = ObjectPool.instance.GetPooledObject();
        Grid grid = GridComponent.GetGrid();

        if (tile != null) 
        {
            tile.SetActive(true);
            TilesetComponent tilesetComponent = tile.GetComponent<TilesetComponent>();
            tilesetComponent.cameraDeathZone = cameraDeathZone;

            if (lastSpawnedTile != null)
            {
                tilesetComponent.Index = lastSpawnedTile.Index + lastSpawnedTile.Size;
            }
            else
            {
                tilesetComponent.Index = 0;
            }
            
            tile.transform.position = grid.CellToWorld(new Vector3Int(0, tilesetComponent.Index, 0)) + (float)tilesetComponent.Size / 2f * grid.cellSize.y * Vector3.forward;
            lastSpawnedTile = tilesetComponent;

            //initialize the car position
            tilesetComponent.gridIndex = grid.WorldToCell(tile.transform.position);
            tile.GetComponentInChildren<CarComponent>().gridIndex = new Vector3Int(tilesetComponent.gridIndex.x+
                tile.GetComponentInChildren<CarComponent>().carStartGridPositionOffset.x,
            tilesetComponent.gridIndex.y + tile.GetComponentInChildren<CarComponent>().carStartGridPositionOffset.y,
            tilesetComponent.gridIndex.z + tile.GetComponentInChildren<CarComponent>().carStartGridPositionOffset.z);

            //Vector3Int debug = grid.WorldToCell(tile.transform.position);
        }
    }



}
