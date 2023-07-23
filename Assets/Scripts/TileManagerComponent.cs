using UnityEngine;


public class TileManagerComponent : MonoBehaviour
{
    public TilesetComponent lastSpawnedTile;
    public Grid grid;
    public GameObject debug;
    public GameObject tilesetCheckerObject;
    public GameObject cameraDeathZone;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("tile spawned (tilemanager Start func)");
        SpawnTiles();
    }
    private void OnEnable()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTiles()
    {
        GameObject tile = ObjectPool.instance.GetPooledObject();

        if(tile != null) 
        {
            tile.SetActive(true);
            TilesetComponent tilesetComponent = tile.GetComponent<TilesetComponent>();
            tile.GetComponentInChildren<CarComponent>().grid = grid;
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
