using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI startText;
    public Button restartButton;
    public Button gobackToMainButton;
    public Button startButton;

    private const string mainSceneName = "MainScene";
    
    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
        }

        if (startText == null)
        {
            Debug.LogError("startText is null");
        }

        if (startButton == null)
        {
            Debug.LogError("startButton is null");
        }
        GameManager.Instance.Stop();
        
        startButton.onClick.AddListener(SetStart);
        startText.gameObject.SetActive(true);
        
        restartText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gobackToMainButton.gameObject.SetActive(false);
    }

    public void SetStart()
    {
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        GameManager.Instance.GameStart();
    }
    
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gobackToMainButton.gameObject.SetActive(true);
        
        restartButton.onClick.AddListener(GameManager.Instance.RestartGame);
        gobackToMainButton.onClick.AddListener(GobackToMain);
    }

    public void GobackToMain()
    {
        SceneChanger.Load(mainSceneName);
    }

    public void UpdateScore(int score, int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }
}