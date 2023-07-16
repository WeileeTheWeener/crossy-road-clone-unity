using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Vector3Int gridIndex;
    public UnityEvent onMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        gridIndex = grid.WorldToCell(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) 
        {
            gridIndex.x++;
        }
        if(Input.GetKeyDown(KeyCode.A))
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
}
