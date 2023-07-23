using System.Collections.Generic;
using UnityEngine;


public class GameFlowComponent : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    public static GameFlowComponent instance; 
    public List<DeathZoneVehicleComponent> deathZones;
    public GameObject player;
    public PlayerDeathComponent playerDeathComponent;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerDeathComponent = player.GetComponent<PlayerDeathComponent>();
    }

    public static void AddDeathZoneVehicleComponent(DeathZoneVehicleComponent deathZoneVehicleComponent)
    {
        instance.deathZones.Add(deathZoneVehicleComponent);
    }
    public static void RemoveDeathZoneVehicleComponent(DeathZoneVehicleComponent deathZoneVehicleComponent)
    {
        instance.deathZones.Remove(deathZoneVehicleComponent);
    }
    public static void RemoveAllDeathZoneVehicleComponents()
    {
        instance.deathZones.Clear();
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
