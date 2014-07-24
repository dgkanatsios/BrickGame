using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        Ball = GameObject.Find("Ball").GetComponent<BallScript>();
    }


    private bool InputTaken()
    {
        return Input.touchCount > 0 || Input.GetMouseButtonUp(0);
    }


    // Update is called once per frame
    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Start:
                if (InputTaken())
                {
                    CurrentGameState = GameState.Playing;
                    Ball.StartBall();
                }
                break;
            case GameState.Playing:
                break;
            case GameState.Won:
                if (InputTaken())
                {
                    Restart();
                    Ball.StartBall();
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostALife:
                if (InputTaken())
                {
                    Ball.StartBall();
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostAllLives:
                if (InputTaken())
                {
                    Restart();
                    Ball.StartBall();
                    CurrentGameState = GameState.Playing;
                }
                break;
            default:
                break;
        }
    }

    private void Restart()
    {
        foreach (var item in blocks)
        {
            item.SetActive(true);
            item.GetComponent<BlockScript>().InitializeColor();
        }
        Lives = 3;
        Score = 0;
    }

    void OnGUI()
    {
        switch (CurrentGameState)
        {
            case GameState.Start:
                GUI.Label(new Rect(10, Screen.height / 2, 300, 100), "Tap to play");
                break;
            case GameState.Playing:
                GUI.Label(new Rect(10, 0, 300, 100), string.Format("Lives: {0}  Score: {1}", Lives, Score));
                break;
            case GameState.Won:
                GUI.Label(new Rect(10, Screen.height / 2, 300, 100), "Won. Tap to play again");
                break;
            case GameState.LostALife:
                GUI.Label(new Rect(10, Screen.height / 2, 300, 100), "Lost a life. Tap to continue");
                break;
            case GameState.LostAllLives:
                GUI.Label(new Rect(10, Screen.height / 2, 300, 100), "Lost all lives. Tap to play again");
                break;
            default:
                break;
        }


    }

    internal static void DecreaseLives()
    {
        if (Lives > 0)
            Lives--;

        if(Lives == 0)
        {
            CurrentGameState = GameState.LostAllLives;
        }
        else
        {
            CurrentGameState = GameState.LostALife;
        }
        Ball.StopBall();
    }

    public static int Lives = 3;
    public static int Score = 0;
    public static int BlocksAlive = 20;
    public static GameState CurrentGameState = GameState.Start;

    public static BallScript Ball;
    private GameObject[] blocks;

    public enum GameState
    {
        Start,
        Playing,
        Won,
        LostALife,
        LostAllLives
    }
}
