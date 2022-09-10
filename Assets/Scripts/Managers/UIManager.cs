using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject winImage;
    public GameObject gameOverImage;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        winImage.SetActive(false);
        gameOverImage.SetActive(false);
    }

    public void ShowWin()
    {
        winImage.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverImage.SetActive(true);
    }





}
