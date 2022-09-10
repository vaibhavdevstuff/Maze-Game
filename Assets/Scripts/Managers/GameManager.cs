using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool gameEnd;

    public bool GameEnd { get { return gameEnd; } }

    private void Awake()
    {
        gameEnd = false;

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void GameWin()
    {
        gameEnd = true;

        UIManager.Instance.ShowWin();

        Invoke(nameof(LoadMenu), 2f);
    }

    public void GameOver()
    {
        gameEnd = true;

        UIManager.Instance.ShowGameOver();

        Invoke(nameof(LoadMenu), 2f);
    }

    private void LoadMenu()
    {
        SceneController.Instance.LoadMenuScene();
    }















}
