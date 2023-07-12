using UnityEngine;

public class TilesetTriggerComponent : MonoBehaviour
{
    [SerializeField] TileManagerComponent tileManager;
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.transform.root.GetComponent<TilesetComponent>() != null)
        {
            if (collision.gameObject == collision.gameObject.transform.root.GetComponent<TilesetComponent>().LastTile)
            {
                Debug.Log("spawn tile");
                tileManager.SpawnTiles();
            }
        }
    }
}
