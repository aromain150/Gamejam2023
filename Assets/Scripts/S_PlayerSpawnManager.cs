using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerSpawnManager : MonoBehaviour
{

    public PlayerInput playerSlot1;
    public PlayerInput playerSlot2;

    void OnPlayerJoined(PlayerInput playerInput)
    {

        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);


        if (playerSlot1 == null)
        {
            playerSlot1 = playerInput;
            //playerSlot1.gameObject.SetActive(false);
            return;
        }

        if (playerSlot2 == null)
        {
            playerSlot2 = playerInput;
            //playerSlot2.gameObject.SetActive(false);
            return;
        }

        Destroy(playerInput.gameObject);
    }

    void StartGame()
    {
        if (playerSlot1!= null && playerSlot2!=null)
        {
            playerSlot1.gameObject.SetActive(true);
            playerSlot2.gameObject.SetActive(true);
        }
    }


    void OnPlayerLeft(PlayerInput playerInput)
    {

        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

    }
}
