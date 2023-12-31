using UnityEngine;

public class TilesetComponent : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private int index;
    [SerializeField] private GameObject lastTile;
    public GameObject cameraDeathZone;

    private Grid grid;
    public Vector3Int gridIndex;

    public int Size { get => size; set => size = value; }
    public GameObject LastTile { get => lastTile; set => lastTile = value; }
    public int Index { get => index; set => index = value; }

    private void Start()
    {
        grid = GridComponent.GetGrid();
    }
    private void Update()
    {
        DisableTileOnOutOfBounds();
    }
    private void DisableTileOnOutOfBounds()
    {
        Vector3 lastCellPos = grid.CellToWorld(grid.WorldToCell(lastTile.transform.position) + new Vector3Int(0,1,0));
        //Debug.Log(gameObject.name+": "+ lastCellPos);

        if ((lastCellPos.z < cameraDeathZone.transform.position.z) && gameObject.name !="start_tile")
        {
            gameObject.SetActive(false);
        }
        

    }

}
