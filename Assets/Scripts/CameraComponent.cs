using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraComponent : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deathZoneObject;
    [SerializeField] private Vector3 deathZoneObjectOffset;
    [SerializeField] private PlayerDeathComponent playerDeathComponent;
    private Vector3 startingPosition;

    private void Start()
    {
        playerDeathComponent = player.GetComponent<PlayerDeathComponent>();
        startingPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        DeathZone();

    }
    private void Move()
    {
        transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }
    private void DeathZone()
    {
        deathZoneObject.transform.position = transform.position + deathZoneObjectOffset;

        if(deathZoneObject.transform.position.z > player.transform.position.z)
        {
            //todo make a player death component invoke this in there if player is alive(done)
            //onPlayerDeath?.Invoke();
            playerDeathComponent.HandleDeath();
            playerDeathComponent.isAlive = false;
            Debug.Log("player is dead(out of zone)");
        }

    }
    public void ResetCameraPosition()
    {
        transform.position = startingPosition;
    }

}

