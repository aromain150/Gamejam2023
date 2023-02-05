using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S_GameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI VictoryMessage;
    [SerializeField] GameObject GameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.OnGameFinished += GameEndMessage; 
    }

    public void GameEndMessage()
    {
        GameoverPanel.SetActive(true);
        VictoryMessage.text = ScoreManager.Instance.GetWinner();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
}
