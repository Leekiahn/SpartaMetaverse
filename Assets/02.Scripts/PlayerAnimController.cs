using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator playerAnim = null;
    private AnimatorController playerAnimatorController;
    private const string IsMoving = "isMoving";

    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerAnimatorController = GetComponent<AnimatorController>();
        if (playerAnim == null) { Debug.LogError("Animator is null"); }
    }

    public void MoveAnim(Vector3 dir)
    {
        playerAnim.SetBool(IsMoving, dir.magnitude > 0.2f);
    }
}
