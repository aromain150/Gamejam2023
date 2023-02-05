using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_UIPlayerSpawnManagerDisplayer : MonoBehaviour
{

    [SerializeField] S_PlayerSpawnManager playerSpawnManager;
    [SerializeField] GameObject LoadingPlayer1;
    [SerializeField] GameObject FoundPlayer1;
    [SerializeField] GameObject LoadingPlayer2;
    [SerializeField] GameObject FoundPlayer2;
    [SerializeField] Canvas PlayerCOnectUI;
    [SerializeField] Button StartButton;


    // Start is called before the first frame update
    void Start()
    {
        StartButton.interactable = false;
        DisplayConnected();
        playerSpawnManager.OnChange += DisplayConnected;
        playerSpawnManager.OnGameStarted += HideDisplay;
    }

    private void DisplayConnected()
    {

        LoadingPlayer1.SetActive((playerSpawnManager.playerSlot1 == false));
        FoundPlayer1.SetActive((playerSpawnManager.playerSlot1 == true));

        LoadingPlayer2.SetActive((playerSpawnManager.playerSlot2 == false));
        FoundPlayer2.SetActive((playerSpawnManager.playerSlot2 == true));

        StartButton.interactable = (playerSpawnManager.playerSlot2 && playerSpawnManager.playerSlot1);

    }

    private void HideDisplay()
    {
        PlayerCOnectUI.enabled = false;
    }

}
