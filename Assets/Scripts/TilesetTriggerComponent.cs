using UnityEngine;

public class TilesetTriggerComponent : MonoBehaviour
{
    [SerializeField] TileManagerComponent tileManager;
    [SerializeField] Vector3 startPos;
    [SerializeField] private Vector3 tilesetCheckerObjectOffset;

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.transform.root.GetComponent<TilesetComponent>() != null)
        {
            if (collision.gameObject == collision.gameObject.transform.root.GetComponent<TilesetComponent>().LastTile)
            {
                Debug.Log("tile spawned (tile set checker triggered)");
                Debug.Log("collision g.o: "+collision.gameObject.name);
                tileManager.SpawnTiles();
            }
        }
    }
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        UpdatePosition();
    }
    public void SetPositionToStartPosition()
    {
        //tilesetCheckerObjectOffset.z = 33;
        Debug.Log("asdasd");
    }
    public void UpdatePosition()
    {
        transform.position = Camera.main.transform.position + tilesetCheckerObjectOffset;
    }
}
