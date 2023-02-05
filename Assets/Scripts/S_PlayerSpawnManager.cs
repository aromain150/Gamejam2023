using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class S_PlayerSpawnManager : MonoBehaviour
{

    public delegate void PlayerSpawnManagerDelegate();
    public PlayerSpawnManagerDelegate OnChange;
    public PlayerSpawnManagerDelegate OnGameStarted;

    public PlayerInput playerSlot1;
    public PlayerInput playerSlot2;

    public Transform spawn1;
    public Transform spawn2;

    public PositionConstraint positionConstraint;

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

    S_PlayerStateMachine playerStateMachine1;
    S_PlayerStateMachine playerStateMachine2;


    public void StartGame()
    {
        if (playerSlot1 != null && playerSlot2 != null)
        {
            playerStateMachine1 = playerSlot1.GetComponent<S_PlayerStateMachine>();
            playerStateMachine1.SwitchState(new FreeMotion(playerStateMachine1));
            playerStateMachine1.modelHandler.SetPlayer(0);

            playerStateMachine2 = playerSlot2.GetComponent<S_PlayerStateMachine>();
            playerStateMachine2.SwitchState(new FreeMotion(playerStateMachine2));
            playerStateMachine2.modelHandler.SetPlayer(1);


            ConstraintSource CS = new ConstraintSource();
            CS.sourceTransform = playerSlot1.transform;
            CS.weight = 1;
            positionConstraint.AddSource(CS);

            ConstraintSource CS2 = new ConstraintSource();
            CS2.sourceTransform = playerSlot2.transform;
            CS2.weight = 1;
            positionConstraint.AddSource(CS2);


            ScoreManager.Instance.StartCountDown();
            OnGameStarted?.Invoke();
        }
    }

    public void EndGame()
    {
        foreach (S_PlayerStateMachine item in FindObjectsOfType<S_PlayerStateMachine>())
        {
            item.SwitchState(new NoMotion(item));
        }
    }

}
