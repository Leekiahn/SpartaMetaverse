using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappPlaneDoor : MonoBehaviour
{
    [SerializeField] private GameObject flappPlaneUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!flappPlaneUI.activeSelf)
        {
            flappPlaneUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (flappPlaneUI.activeSelf)
        {
            flappPlaneUI.SetActive(false);
        }
    }
}
