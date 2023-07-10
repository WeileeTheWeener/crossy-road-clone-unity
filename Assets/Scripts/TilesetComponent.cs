using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesetComponent : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private int index;
    [SerializeField] private GameObject lastTile;

    public Grid grid;
    public Vector3Int gridIndex;

    public int Size { get => size; set => size = value; }
    public GameObject LastTile { get => lastTile; set => lastTile = value; }

    private void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<Grid>();
    }
    private void Update()
    {
        gridIndex = grid.WorldToCell(gameObject.transform.position);
    }
}
