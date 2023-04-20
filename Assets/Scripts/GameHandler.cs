/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;

public class GameHandler : MonoBehaviour {

    //private static GameHandler instance;
    private static int score;
    [SerializeField] private Snake snake;
    private LevelGrid levelGrid;

    private void Start() {
        Debug.Log("GameHandler.Start");
        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

    }

    private void Awake()
    {
        //instance = this;
        InitializeStatic();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused())
                GameHandler.ResumeGame();
            else
                GameHandler.PauseGame();
        }
    }

    public static int getScore()
    {
        return score;
    }

    public static void addScore()
    {
        score += 100;
    }

    private static void InitializeStatic()
    {
        score = 0;
    }

    public static void SnakeDied()
    {
        GameOverWindow.ShowStatic();
    }

    public static void ResumeGame() {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }

    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

}
