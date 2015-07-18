using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Text statusText;

    // Use this for initialization
    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        Ball = GameObject.Find("Ball").GetComponent<BallScript>();
        statusText = GameObject.Find("Status").GetComponent<Text>();
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
                    statusText.text = string.Format("Lives: {0}  Score: {1}", Lives, Score);
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
                    statusText.text = string.Format("Lives: {0}  Score: {1}", Lives, Score);
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostALife:
                if (InputTaken())
                {
                    Ball.StartBall();
                    statusText.text = string.Format("Lives: {0}  Score: {1}", Lives, Score);
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostAllLives:
                if (InputTaken())
                {
                    Restart();
                    Ball.StartBall();
                    statusText.text = string.Format("Lives: {0}  Score: {1}", Lives, Score);
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

  
    public void DecreaseLives()
    {
        if (Lives > 0)
            Lives--;

        if(Lives == 0)
        {
            statusText.text = "Lost all lives. Tap to play again";
            CurrentGameState = GameState.LostAllLives;
        }
        else
        {
            statusText.text = "Lost a life. Tap to continue";
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
