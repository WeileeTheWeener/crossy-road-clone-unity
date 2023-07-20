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
    [SerializeField] private Vector3 tilesetCheckerObjectOffset;
    [SerializeField] private GameObject tiles;

    // Start is called before the first frame update
    void Start()
    {
        onEndReached.AddListener(SpawnTiles);
        SpawnTiles();
    }
    // Update is called once per frame
    void Update()
    {
       UpdateTilesetCheckerObject();

       /*if (Input.GetMouseButtonDown(0))
       {
            SpawnTiles();
       }*/
        
    }
    public void SpawnTiles()
    {
        int tileToSpawn = Random.Range(0, tileList.Count);
        GameObject tile = GameObject.Instantiate(tileList[tileToSpawn]);
        TilesetComponent tilesetComponent = tile.GetComponent<TilesetComponent>();
        tile.GetComponentInChildren<CarComponent>().grid = grid;

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
    }
    private void UpdateTilesetCheckerObject()
    {
        tilesetCheckerObject.transform.position = Camera.main.transform.position + tilesetCheckerObjectOffset;
    }

}
