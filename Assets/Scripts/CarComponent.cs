using UnityEngine;

public class CarComponent : MonoBehaviour
{
    public Grid grid;
    public GameObject tileManager;
    [SerializeField] private float movementRate;
    [SerializeField] private float timeLeftToMove;
    [SerializeField] private bool canMove;
    [SerializeField] private GameObject roadCheckRayObject;
    public Vector3Int gridIndex;
    [SerializeField] Vector3 startWorldPosition;
    public Vector3Int carStartGridPositionOffset;

    private void OnEnable()
    {
        startWorldPosition = transform.position;
        timeLeftToMove = movementRate;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }
    private void FixedUpdate()
    {
        CheckIfCanMove();
    }
    void Movement()
    {
        timeLeftToMove -= Time.deltaTime;
        timeLeftToMove= Mathf.Clamp(timeLeftToMove, 0, movementRate);

        if(timeLeftToMove == 0 && canMove)
        {
            timeLeftToMove = movementRate;
            gridIndex.x++;
        }
        //loop through if next tile has no road
        else if(timeLeftToMove == 0 && !canMove)
        {
            gridIndex.x = grid.WorldToCell(startWorldPosition).x;
            timeLeftToMove = movementRate;
        }
        transform.position = grid.CellToWorld(gridIndex);
    }
    void CheckIfCanMove()
    {
        Ray ray = new Ray();
        ray.origin = roadCheckRayObject.transform.position;
        ray.direction = Vector3.down;
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            canMove = true;
        }
        else
        {
            canMove = false;
           
        }
    }
   
    
}
