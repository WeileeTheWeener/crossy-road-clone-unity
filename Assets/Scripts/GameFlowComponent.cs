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
    public PlayerDeathComponent playerDeathComponent;
    public Grid grid;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerDeathComponent = player.GetComponent<PlayerDeathComponent>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(DeathZoneVehicleComponent deathZone in deathZones)
        {
            if (deathZone.CheckIfInDeathZone(grid.WorldToCell(player.transform.position),grid))
            {
                //onPlayerDeath?.Invoke();
                Debug.Log("player is dead(collision)");           
                playerDeathComponent.HandleDeath();
                playerDeathComponent.isAlive = false;

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
