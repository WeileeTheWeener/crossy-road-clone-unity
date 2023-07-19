using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private Grid grid;
    public Vector3Int gridIndex;
    public UnityEvent onMoveForward;
    Vector3Int tileLeftOfPlayer;
    Vector3Int tileRightOfPlayer;
    Vector3Int tileBehindThePlayer;
    [SerializeField] bool canMoveLeft;
    [SerializeField] bool canMoveRight;
    [SerializeField] bool canMoveBack;
    [SerializeField] Vector3 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        gridIndex = grid.WorldToCell(gameObject.transform.position);
        transform.position = grid.CellToWorld(gridIndex);
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
        transform.position = grid.CellToWorld(gridIndex);

    }
    void CheckIfICanMove()
    {
        tileLeftOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(gridIndex.x - 1, gridIndex.y, gridIndex.z)));
        tileRightOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(gridIndex.x + 1, gridIndex.y, gridIndex.z)));
        tileBehindThePlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(gridIndex.x, gridIndex.y-1, gridIndex.z)));

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
    }
}
