using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] TileManagerComponent tileManager;
    [SerializeField] int poolAmount;
    [SerializeField] private List<GameObject> tilePrefabs;
    public List<GameObject> pooledObjects = new List<GameObject>();
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        CreateObjectPool();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnEnable()
    {
        //if the pool is destroyed create
        if(pooledObjects.Count == 0)
        {
            CreateObjectPool();
            tileManager.SpawnTiles();
        }
    }
    private void OnDisable()
    {
        DestroyThePool();
    }
    public void DestroyThePool()
    {
        foreach (GameObject obj in pooledObjects) 
        {
            Destroy(obj);
            
        }
        pooledObjects.Clear();


    }
    public void CreateObjectPool()
    {
        for (int x = 0; x < tilePrefabs.Count; x++)
        {
            for (int i = 0; i < poolAmount; i++)
            {
                GameObject obj = Instantiate(tilePrefabs[x]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
                //todo: implement random object returning from the pool
                //pooledUnactiveTiles.Add(pooledObjects[i]);                
            }        
        }
        //int index = Random.Range(0, pooledUnactiveTiles.Count);
        //return pooledUnactiveTiles[index];
        return null;
    }
}
