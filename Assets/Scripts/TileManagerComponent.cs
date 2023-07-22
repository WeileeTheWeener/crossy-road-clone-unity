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
    public GameObject debug;
    public GameObject tilesetCheckerObject;
    public GameObject cameraDeathZone;
    [SerializeField] private Vector3 tilesetCheckerObjectOffset;

    // Start is called before the first frame update
    void Start()
    {
        onEndReached.AddListener(SpawnTiles);
        SpawnTiles();
    }
    // Update is called once per frame
    void Update()
    {
       UpdateTilesetCheckerObjectPosition();
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
    private void UpdateTilesetCheckerObjectPosition()
    {
        tilesetCheckerObject.transform.position = Camera.main.transform.position + tilesetCheckerObjectOffset;
    }


}
