using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int offset;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject player;
    [SerializeField] private float startOffset;

    #if UNITY_EDITOR
        public Transform deathZone;
    #endif
    private void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,player.transform.position.z+startOffset);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        DeathZoneRaycast();
    }
    private void Move()
    {
        transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }
    private void DeathZoneRaycast()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            Vector3Int hitPointCell = grid.WorldToCell(hit.point);
            hitPointCell.y -= offset;

            if (grid.WorldToCell(player.transform.position).y < hitPointCell.y)
            {
                Debug.Log("Player is dead");
            }

        #if UNITY_EDITOR
            deathZone.position = grid.CellToWorld(hitPointCell);
        #endif
        }

    }
}

