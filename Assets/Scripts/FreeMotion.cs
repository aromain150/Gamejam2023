using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FreeMotion : PlayerBaseState
{
    public FreeMotion(S_PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.inputReader.AttackEvent += Attack;
    }

    public override void Exit()
    {
        stateMachine.inputReader.AttackEvent -= Attack;
    }

    public override void Tick(float deltatime)
    {
        Move(deltatime);
    }

    public void Move(float deltatime)
    {
        Debug.Log(stateMachine.inputReader.MovementValue);
        Debug.Log(stateMachine.movement);
        stateMachine.movement.Move(stateMachine.inputReader.MovementValue);

    }

    private void Animate(float deltatime)
    {
   
    }

    public void Attack()
    {
    
    }

}
