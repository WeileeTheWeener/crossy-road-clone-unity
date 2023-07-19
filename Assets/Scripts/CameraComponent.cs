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
    [SerializeField] private UnityEvent onPlayerDeath;
    private Vector3 startingPosition;
    private void Start()
    {
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
            onPlayerDeath?.Invoke();
            Debug.Log("player is dead");
        }

    }
    public void ResetCameraPosition()
    {
        transform.position = startingPosition;
    }

}

