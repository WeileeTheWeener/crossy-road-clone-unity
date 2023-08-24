using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class GridComponent : MonoBehaviour
{
    private static GridComponent instance;
    private Grid grid;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        grid = GetComponent<Grid>();
    }
    void Start()
    {
        
    }
    public static Grid GetGrid()
    {
        return instance.grid;
    }


}
