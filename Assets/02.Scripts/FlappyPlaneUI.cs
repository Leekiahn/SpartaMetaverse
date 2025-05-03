using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyPlaneUI : MonoBehaviour
{
    private const string minigameName = "FlappyPlane";

    [SerializeField] private Button starButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        starButton.onClick.AddListener(OnClickStart);
        exitButton.onClick.AddListener(OnClickExit);
    }
    
    private void OnClickStart()
    {
        SceneChanger.Load(minigameName);
    }

    private void OnClickExit()
    {
        gameObject.SetActive(false);
    }
}
