using UnityEngine;

public class DeathZoneVehicleComponent : MonoBehaviour
{
    private Collider collider;
    private Grid grid;
    public GameObject player;
    public PlayerDeathComponent playerDeathComponent;

    private void OnDisable()
    {
        GameFlowComponent.RemoveDeathZoneVehicleComponent(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameFlowComponent.AddDeathZoneVehicleComponent(this);
        collider = gameObject.GetComponent<Collider>();
        grid = GridComponent.GetGrid();
        playerDeathComponent = player.GetComponent<PlayerDeathComponent>();

    }
    private void Update()
    {
        if (CheckIfInDeathZone(grid.WorldToCell(player.transform.position), grid))
        {
            Debug.Log("player is dead(collision)");
            playerDeathComponent.HandleDeath();
            playerDeathComponent.isAlive = false;

        }
    }
    public bool CheckIfInDeathZone(Vector3Int playerIndex,Grid grid)
    {
        Vector3Int minIndex = grid.WorldToCell(new Vector3(collider.bounds.min.x, 0, collider.bounds.min.z));
        Vector3Int maxIndex = grid.WorldToCell(new Vector3(collider.bounds.max.x, 0, collider.bounds.max.z));

        if (playerIndex.x < minIndex.x ||
            playerIndex.y < minIndex.y ||
            playerIndex.x > maxIndex.x ||
            playerIndex.y > maxIndex.y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
