using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [field: SerializeField] public int ScorePlayer1 { get; private set; }
    [field: SerializeField] public int ScorePlayer2 { get; private set; }
    [field: SerializeField] public float timeLeft { get; private set; }
    bool startCountDown;

    public delegate void ScoreManagerDelegate();
    public ScoreManagerDelegate OnGameStarted;
    public ScoreManagerDelegate OnGameFinished;
    public ScoreManagerDelegate OnScoreChange;

    public void AddScore(int score,string team)
    {
        switch (team)
        {
            case "Player1": ScorePlayer1 += score;
                OnScoreChange?.Invoke();
                break;

            case "Player2": ScorePlayer2 += score;
                OnScoreChange?.Invoke();
                break;

            default:
                break;
        }

        OnScoreChange?.Invoke();
    }

    public string GetWinner()
    {
        if (ScorePlayer1>ScorePlayer2)
        {
            return "PLAYER 1 WON!";
        }
        else if (ScorePlayer1 < ScorePlayer2)
        {
            return "PLAYER 2 WON!";
        }
        else
        {
            return "DRAW!";
        }
    }

    private void Update()
    {
        if (startCountDown)
        {
            CountDown();
        }
    }

    public void StartCountDown()
    {
        startCountDown = true;
        OnGameStarted?.Invoke();
    }

    private void CountDown()
    {
        timeLeft -= Time.deltaTime;
        OnScoreChange?.Invoke();

        if (timeLeft<0)
        {
            timeLeft = 90;
            startCountDown = false;
            OnGameFinished?.Invoke();
        }
    }

}
