using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField] private Slider r;
    [SerializeField] private Slider g;
    [SerializeField] private Slider b;

    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject zombie;
    
    [SerializeField] private SpriteRenderer elfSpriteRenderer;
    [SerializeField] private SpriteRenderer zombieSpriteRenderer;

    private void Awake()
    {
        elfSpriteRenderer = elf.GetComponent<SpriteRenderer>();
        zombieSpriteRenderer = zombie.GetComponent<SpriteRenderer>();

        r.value = 255;
        g.value = 255;
        b.value = 255;
    }

    private void Update()
    {
        if (elf.activeSelf)
        {
            elfSpriteRenderer.color = new Color(r.value/255f, g.value/255f, b.value/255f);
        }
        else if (zombie.activeSelf)
        {
            zombieSpriteRenderer.color = new Color(r.value/255f, g.value/255f, b.value/255f);
        }
    }
}
