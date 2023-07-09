using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowComponent : MonoBehaviour
{
    public static GameFlowComponent instance; 
    public List<DeathZoneVehicleComponent> deathZones;
    public GameObject player;
    public Grid grid;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DeathZoneVehicleComponent deathZone in deathZones)
        {
            if (deathZone.CheckIfInDeathZone(grid.WorldToCell(player.transform.position),grid))
            {
                Debug.Log("dead");
            }
        }
        
    }
    public static void AddDeathZoneVehicleComponent(DeathZoneVehicleComponent deathZoneVehicleComponent)
    {
        instance.deathZones.Add(deathZoneVehicleComponent);
    }
    public static void RemoveDeathZoneVehicleComponent(DeathZoneVehicleComponent deathZoneVehicleComponent)
    {
        instance.deathZones.Remove(deathZoneVehicleComponent);
    }
}
