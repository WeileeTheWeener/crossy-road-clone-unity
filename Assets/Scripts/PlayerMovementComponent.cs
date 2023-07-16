using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Vector3Int gridIndex;
    public UnityEvent onMoveForward;
    Vector3Int tileLeftOfPlayer;
    Vector3Int tileRightOfPlayer;
    [SerializeField] bool canMoveLeft;
    [SerializeField] bool canMoveRight;

    // Start is called before the first frame update
    void Start()
    {
        gridIndex = grid.WorldToCell(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfICanMoveLeftOrRight();
        GridMovement();
        
    }
    void GridMovement()
    {

        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            gridIndex.x++;
        }
        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            gridIndex.x--;
        }  
        if (Input.GetKeyDown(KeyCode.W))
        {
            gridIndex.y++;
            onMoveForward.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gridIndex.y--;
        }

        transform.position = grid.CellToWorld(gridIndex);
    }
    void CheckIfICanMoveLeftOrRight()
    {
        tileLeftOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(gridIndex.x - 1, gridIndex.y, gridIndex.z)));
        tileRightOfPlayer = grid.WorldToCell(grid.CellToWorld(new Vector3Int(gridIndex.x + 1, gridIndex.y, gridIndex.z)));

        Ray rayLeft = new Ray();
        Ray rayRight = new Ray();

        rayLeft.origin = grid.CellToWorld(tileLeftOfPlayer);
        rayLeft.direction = Vector2.down;
        rayRight.origin = grid.CellToWorld(tileRightOfPlayer);
        rayRight.direction = Vector2.down;

        RaycastHit hitLeft = new RaycastHit();
        RaycastHit hitRight = new RaycastHit();

        Debug.DrawRay(rayLeft.origin, rayLeft.direction * 5f,Color.red);
        Debug.DrawRay(rayRight.origin, rayRight.direction * 5f, Color.red);

        if (Physics.Raycast(rayLeft,out hitLeft))
        {
            canMoveLeft = true;
            Debug.Log("Left: " + hitLeft.transform.name);
        }
        else canMoveLeft = false;

        if (Physics.Raycast(rayRight,out hitRight))
        {
            canMoveRight = true;
            Debug.Log("Right: "+hitRight.transform.name);
        }
        else canMoveRight = false;
    }
}
