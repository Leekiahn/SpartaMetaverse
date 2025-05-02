using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float previousSpeed = 0f;
    [SerializeField] private float vehicleSpeed = 2f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        previousSpeed = playerController.MoveSpeed;
    }

    public void RideOnVehicle(Boolean isOnVehicle)
    {
        if (isOnVehicle)
        {
            vehicle.SetActive(true);
            playerController.MoveSpeed = previousSpeed + vehicleSpeed;
        }
        else
        {
            vehicle.SetActive(false);
            playerController.MoveSpeed = previousSpeed;
        }
    }
}
