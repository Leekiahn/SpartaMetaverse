using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    private int bestScore = 0;
    
    private const string BestScoreKey = "BestScore";
    
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0, bestScore);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyPlane");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore >= bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
        uiManager.UpdateScore(currentScore, bestScore);
        Debug.Log("Score: " + currentScore);
    }

    public void Stop()
    {
        Time.timeScale = 0;
    }

}