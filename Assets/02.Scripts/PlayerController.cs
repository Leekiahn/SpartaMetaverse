using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 30)][SerializeField] private float moveSpeed = 3f;    //유닛의 기본 이동속도 1~30
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    SpriteRenderer spriteRenderer;

    PlayerAnimController playerAnim = null;
    
    private VehicleController vehicleController;
    private VehicleAnimController vehicleAnim;
    
    
    [SerializeField] private GameObject elfGameObject;
    [SerializeField] private GameObject zombieGameObject;

    Camera cam;
    
    Boolean isOnVehicle = false;
    
    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimController>();
        if (playerAnim == null) {  Debug.LogError("PlayerAnimController is null"); }
        
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null) { Debug.LogError("SpriteRenderer is null"); }

        vehicleController = GetComponent<VehicleController>();
        vehicleAnim = GetComponentInChildren<VehicleAnimController>();
        
        cam = Camera.main;
    }

    void Update()
    {
        Rotate();
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!zombieGameObject.activeSelf)
            {
                isOnVehicle = !isOnVehicle;
                vehicleController.RideOnVehicle(isOnVehicle);
            }
        }
        else
        {
            if (zombieGameObject.activeSelf)
            {
                isOnVehicle = false;
                vehicleController.RideOnVehicle(isOnVehicle);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Rotate()
    {
        Vector3 mouseInput = Input.mousePosition;   //마우스 입력
        mouseInput = cam.ScreenToWorldPoint(mouseInput);
        
        Vector3 lookDir = mouseInput - transform.position;  //방향
        
        float rotZ = MathF.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //각도
        
        if (rotZ > 90 || rotZ < -90) { spriteRenderer.flipX = true; }   //플립
        else { spriteRenderer.flipX = false; }
    }
    
    
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  //입력
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 moveDir = Vector3.zero;
        moveDir = new Vector3(horizontal, vertical).normalized;     //방향
        
        transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;    //이동
        
        playerAnim?.MoveAnim(moveDir);    //애니메이션
        vehicleAnim?.MoveAnim(moveDir);
    }

    public void ReloadSpriteRenderer()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void CharacterChange(Enum eGameObject)
    {
        switch (eGameObject)
        {
            case global::eGameObject.elf:
                elfGameObject.SetActive(true);
                zombieGameObject.SetActive(false);
                ReloadSpriteRenderer();
                break;
            case global::eGameObject.zombie:
                zombieGameObject.SetActive(true);
                elfGameObject.SetActive(false);
                ReloadSpriteRenderer();
                break;
        }
    }
}
