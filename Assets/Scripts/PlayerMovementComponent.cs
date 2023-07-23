using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementComponent : MonoBehaviour
{
    private Grid grid;
    private Vector3Int gridIndex;
    [SerializeField] UnityEvent onMoveForward;
    Vector3Int tileLeftOfPlayer;
    Vector3Int tileRightOfPlayer;
    Vector3Int tileBehindThePlayer;
    [SerializeField] bool canMoveLeft;
    [SerializeField] bool canMoveRight;
    [SerializeField] bool canMoveBack;
    [SerializeField] Vector3 startingPosition;

    public Vector3Int GridIndex { get => gridIndex;}


    // Start is called before the first frame update
    void Start()
    {
        grid = GridComponent.GetGrid();
        gridIndex = grid.WorldToCell(gameObject.transform.position);
        transform.position = grid.CellToWorld(GridIndex);
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfICanMove();
        GridMovement();
        
    }
    void GridMovement()
    {      
        if (Input.GetKeyUp(KeyCode.D) && canMoveRight)
        {
            gridIndex.x++;         
        }
        if (Input.GetKeyUp(KeyCode.A) && canMoveLeft)
        {
            gridIndex.x--;    
        }  
        if (Input.GetKeyUp(KeyCode.W))
        {
            gridIndex.y++;
            onMoveForward.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.S) && canMoveBack)
        {
            gridIndex.y--;    
        }
        transform.position = grid.CellToWorld(GridIndex);

    }
    void CheckIfICanMove()
    {
        tileLeftOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(GridIndex.x - 1, GridIndex.y, GridIndex.z)));
        tileRightOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(GridIndex.x + 1, GridIndex.y, GridIndex.z)));
        tileBehindThePlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(GridIndex.x, GridIndex.y-1, GridIndex.z)));

        Ray rayLeft = new Ray();
        Ray rayRight = new Ray();
        Ray rayBehind = new Ray();

        rayLeft.origin = grid.CellToWorld(tileLeftOfPlayer);
        rayLeft.direction = Vector2.down;
        rayRight.origin = grid.CellToWorld(tileRightOfPlayer);
        rayRight.direction = Vector2.down;
        rayBehind.origin = grid.CellToWorld(tileBehindThePlayer);
        rayBehind.direction = Vector2.down;

        RaycastHit hitLeft = new RaycastHit();
        RaycastHit hitRight = new RaycastHit();
        RaycastHit hitBehind = new RaycastHit();

        Debug.DrawRay(rayLeft.origin, rayLeft.direction * 5f,Color.red);
        Debug.DrawRay(rayRight.origin, rayRight.direction * 5f, Color.red);
        Debug.DrawRay(rayBehind.origin, rayBehind.direction * 5f, Color.red);

        if (Physics.Raycast(rayLeft,out hitLeft))
        {
            canMoveLeft = true;
            //Debug.Log("Left: " + hitLeft.transform.name);
        }
        else canMoveLeft = false;

        if (Physics.Raycast(rayRight,out hitRight))
        {
            canMoveRight = true;
            //Debug.Log("Right: "+hitRight.transform.name);
        }
        else canMoveRight = false;

        if (Physics.Raycast(rayBehind, out hitBehind))
        {
            canMoveBack = true;
            //Debug.Log("Right: "+hitRight.transform.name);
        }
        else canMoveBack = false;
    }
    public void ResetPlayerPosition()
    {
        gridIndex = grid.WorldToCell(startingPosition);
        transform.position = grid.CellToWorld(GridIndex);
    }
}
