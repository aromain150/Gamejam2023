using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected S_PlayerStateMachine stateMachine;

    public PlayerBaseState(S_PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
