using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAnimController : MonoBehaviour
{
    private Animator vehicleAnim;

    private void Awake()
    {
        vehicleAnim = GetComponent<Animator>();
    }

    public void MoveAnim(Vector3 dir)
    {
        vehicleAnim.SetBool("IsMoving",  dir.magnitude > 0.2f);
    }
}
