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
        stateMachine.agent.speed = stateMachine.defaultSpeed;
        stateMachine.inputReader.AttackEvent += Attack;

        stateMachine.modelHandler.SetIdle();
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
        stateMachine.movement.Move(stateMachine.inputReader.MovementValue);
    }

    private void Animate(float deltatime)
    {
   
    }

    public void Attack()
    {

        SO_Pickup pickup = stateMachine.interact.StealFromPlayers(stateMachine);
        if (pickup!= null)
        {
            stateMachine.SwitchState(new HoldMotion(stateMachine, pickup));
            return;
        }

        if (stateMachine.PickupRadar.currentPickUpSpawner != null)
        {
            pickup = stateMachine.PickupRadar.currentPickUpSpawner.GetPickup();
            if (pickup != null) 
            {
                stateMachine.SwitchState(new HoldMotion(stateMachine, pickup));
            }
        }
    }
}
