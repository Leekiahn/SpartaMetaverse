using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private GameObject player = null;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player"); 
        if (player == null) { Debug.LogError("There is no GameObject with Tag (Player)"); }
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}