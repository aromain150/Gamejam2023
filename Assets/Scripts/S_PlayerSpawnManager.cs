using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerSpawnManager : MonoBehaviour
{

    public delegate void PlayerSpawnManagerDelegate();
    public PlayerSpawnManagerDelegate OnChange;
    public PlayerSpawnManagerDelegate OnGameStarted;

    public PlayerInput playerSlot1;
    public PlayerInput playerSlot2;

    public Transform spawn1;
    public Transform spawn2;

    private void Awake()
    {
        ScoreManager.Instance.OnGameFinished += EndGame;
    }

    void OnPlayerJoined(PlayerInput playerInput)
    {

        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);


        if (playerSlot1 == null)
        {
            playerSlot1 = playerInput;
            playerSlot1.transform.position = spawn1.position;

            OnChange?.Invoke();
            return;
        }

        if (playerSlot2 == null)
        {
            playerSlot2 = playerInput;
            playerSlot2.transform.position = spawn2.position;

            OnChange?.Invoke();
            return;
        }

        Destroy(playerInput.gameObject);
    }


    void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        OnChange?.Invoke();
    }


    public void StartGame()
    {
        if (playerSlot1 != null && playerSlot2 != null)
        {
            S_PlayerStateMachine playerStateMachine = playerSlot1.GetComponent<S_PlayerStateMachine>();
            playerStateMachine.SwitchState(new FreeMotion(playerStateMachine));

            playerStateMachine = playerSlot2.GetComponent<S_PlayerStateMachine>();
            playerStateMachine.SwitchState(new FreeMotion(playerStateMachine));

            ScoreManager.Instance.StartCountDown();
            OnGameStarted?.Invoke();
        }
    }

    public void EndGame()
    {
        S_PlayerStateMachine playerStateMachine = playerSlot1.GetComponent<S_PlayerStateMachine>();
        playerStateMachine?.SwitchState(new NoMotion(playerStateMachine));

        playerStateMachine = playerSlot2.GetComponent<S_PlayerStateMachine>();
        playerStateMachine?.SwitchState(new NoMotion(playerStateMachine));
    }

}
