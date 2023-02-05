using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_UIGameDiplayer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Player1Score;
    [SerializeField] TextMeshProUGUI Player2Score;
    [SerializeField] TextMeshProUGUI Timer;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.OnScoreChange += UpdateUI;
    }

    // Update is called once per frame
    void UpdateUI()
    {
        Player1Score.text = ScoreManager.Instance.ScorePlayer1.ToString("F0");
        Player2Score.text = ScoreManager.Instance.ScorePlayer2.ToString("F0");
        Timer.text = ScoreManager.Instance.timeLeft.ToString("F0");
    }
}
