using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public CanvasController canvasController;
    private PlayerController playerController;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        playerController.EnableInputs(false);
    }

    public void InitGame()
    {
        canvasController.InitGame();
        playerController.EnableInputs(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        InitGame();
    }

    internal void QuitPressed()
    {
        canvasController.ShowQuitPanel();
    }
}
