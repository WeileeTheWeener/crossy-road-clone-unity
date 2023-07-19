using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFlowComponent : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    public static GameFlowComponent instance; 
    public List<DeathZoneVehicleComponent> deathZones;
    public GameObject player;
    public Grid grid;
    [SerializeField] private UnityEvent onPlayerDeath;
    

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
                onPlayerDeath?.Invoke();
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
    public void OpenGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        player.SetActive(false);
    }
    public void CloseGameScreen()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1.0f;
        player.SetActive(true);
    }

}
