using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (!menu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
