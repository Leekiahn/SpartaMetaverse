using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleLook : MonoBehaviour
{
    Camera cam;
    
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) { Debug.LogError("SpriteRenderer is null"); }
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 mouseInput = Input.mousePosition;   //마우스 입력
        mouseInput = cam.ScreenToWorldPoint(mouseInput);
        
        Vector3 lookDir = mouseInput - transform.position;  //방향
        
        float rotZ = MathF.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //각도
        
        if (rotZ > 90 || rotZ < -90) { spriteRenderer.flipX = true; }   //플립
        else { spriteRenderer.flipX = false; }
    }
}
