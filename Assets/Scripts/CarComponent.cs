using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour
{
    public Grid grid;
    private Vector3Int gridIndex;
    public float movementRate;
    public float timeLeftToMove;
    public bool canMove;
    public GameObject roadCheckRayObject;
    public GameObject player;
    private Vector3 startPosition;
    private Collider collider;


    // Start is called before the first frame update
    void Start()
    {
        gridIndex = grid.WorldToCell(gameObject.transform.position);
        transform.position = grid.CellToWorld(gridIndex);
        collider = gameObject.GetComponent<Collider>();
        startPosition = transform.position;
        timeLeftToMove = movementRate;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
            transform.position = grid.CellToWorld(gridIndex);
        }
        //loop through if next tile has no road
        else if(!canMove)
        {
            gridIndex.x = grid.WorldToCell(startPosition).x;
            transform.position = grid.CellToWorld(gridIndex);
        }
        
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
