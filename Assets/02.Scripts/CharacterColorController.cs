using System;
using UnityEngine;

public class CharacterColorController : MonoBehaviour
{
    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject zombie;

    private SpriteRenderer elfSpriteRenderer;
    private SpriteRenderer zombieSpriteRenderer;

    [SerializeField] private GameObject colorUI;
    
    private void Awake()
    {
        elfSpriteRenderer = elf.GetComponent<SpriteRenderer>();
        zombieSpriteRenderer = zombie.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (colorUI.activeSelf)
            {
                colorUI.SetActive(false);
            }
            else
            {
                colorUI.SetActive(true);
            }
            
        }
    }
}