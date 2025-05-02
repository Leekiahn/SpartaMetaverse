using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public enum eGameObject
{
    elf,
    zombie
}

public class SpriteChanger : MonoBehaviour
{

    [SerializeField] private Button elfButton;
    [SerializeField] private Button zombieButton;
    
    [SerializeField] private GameObject ChangeCharacterUI;

    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        elfButton.onClick.AddListener(ChangeToElf);
        zombieButton.onClick.AddListener(ChangeToZombie);
    }

    void ChangeToElf()
    {
        playerController.CharacterChange(eGameObject.elf);
        ChangeCharacterUI.SetActive(false);
    }

    void ChangeToZombie()
    {
        playerController.CharacterChange(eGameObject.zombie);
        ChangeCharacterUI.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController = other.GetComponent<PlayerController>();
        ChangeCharacterUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ChangeCharacterUI.SetActive(false);
    }
}
