using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player          Player;
    public ObstacleSpawner ObstacleSpawner;

    public GameObject Settings, Shop, Difficulty, MainMenu, Gameplay, EndGame, IngameUI;

    public TMP_Text ScoreText;

    public static int Score = 0;

    private bool _isGameStarted = false;

    public static string         Language = "eng";
    public static Action         LanguageChanged;
    public static Action<Sprite> ChangePlayer;
    public static Action         UpdateScore;

    private void OnEnable()
    {
        ChangePlayer               += OnPlayerChanged;
        Player.PlayerTouchObstacle += OnObstacleTouched;
        UpdateScore                += OnScoreUpdated;
    }

    private void OnScoreUpdated()
    {
        Score          += 1;
        ScoreText.text =  Score.ToString();
    }

    private void OnObstacleTouched()
    {
        _isGameStarted = false;
        Gameplay.SetActive(false);
        StopGame();
        EndGame.SetActive(true);
    }

    private void OnPlayerChanged(Sprite obj)
    {
        Player.SpriteRenderer.sprite = obj;
    }

    public void RestartGame()
    {
        Score          = 0;
        ScoreText.text = Score.ToString();
        _isGameStarted = true;
        Gameplay.SetActive(true);
        Player.ResetPosition();
        StartGame();
    }

    public void StartGame()
    {
        EndGame.SetActive(false);
        IngameUI.SetActive(true);
        Player.StartGame();
        ObstacleSpawner.StartSpawningObstacles();
    }

    private void StopGame()
    {
        Player.StopGame();
        ObstacleSpawner.StopSpawningObstacles();
    }

    public void SettingsButton()
    {
        Shop.SetActive(false);
        Settings.SetActive(true);
        if (_isGameStarted)
        {
            StopGame();
        }
    }

    public void ShopButton()
    {
        Settings.SetActive(false);
        Shop.SetActive(true);
        if (_isGameStarted)
        {
            StopGame();
        }
    }

    public void HideSettings()
    {
        Settings.SetActive(false);
        if (_isGameStarted)
        {
            StartGame();
        }
    }

    public void HideShop()
    {
        Shop.SetActive(false);
        if (_isGameStarted)
        {
            StartGame();
        }
    }

    public void DifficultyButton()
    {
        Difficulty.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void BackToHome()
    {
        MainMenu.SetActive(true);
        Difficulty.SetActive(false);
        EndGame.SetActive(false);
        IngameUI.SetActive(false);
        if (_isGameStarted)
        {
            _isGameStarted = false;
            StopGame();
        }

        Gameplay.SetActive(false);
    }

    public void ShowMenu()
    {
        Gameplay.SetActive(false);
        Difficulty.SetActive(false);
        EndGame.SetActive(false);
        IngameUI.SetActive(false);
        if (_isGameStarted)
        {
            _isGameStarted = false;
            StopGame();
        }

        MainMenu.SetActive(true);
    }

    public void SetDifficulty(float speed)
    {
        ObstacleSpawner.ObstacleMoveSpeed = speed;
        Gameplay.SetActive(true);
        Difficulty.SetActive(false);
        _isGameStarted = true;
        Score          = 0;
        ScoreText.text = Score.ToString();
        Player.ResetPosition();
        StartGame();
    }
}