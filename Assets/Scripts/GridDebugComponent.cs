using UnityEngine;

public class GridDebugComponent : MonoBehaviour
{
    [SerializeField] Grid grid;

    // Update is called once per frame
    void Update()
    {
       Debug.Log("debug cell pos: "+grid.WorldToCell(gameObject.transform.position));
    }
}
