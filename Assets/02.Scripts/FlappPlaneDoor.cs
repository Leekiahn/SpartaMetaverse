using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappPlaneDoor : MonoBehaviour
{
    [SerializeField] private GameObject flappPlaneUI;

    private void OnTriggerStay2D(Collider2D other)
    {
        flappPlaneUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        flappPlaneUI.SetActive(false);
    }
}
