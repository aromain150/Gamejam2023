using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FreeMotion : PlayerBaseState
{

    SO_Pickup currentPickupSpawner;

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
         stateMachine.movement.Move(stateMachine.inputReader.MovementValue);
   
    }

    private void Animate(float deltatime)
    {
   
    }

    public void Attack()
    {
        if (stateMachine.PickupRadar.currentPickUpSpawner != null)
        {
            currentPickupSpawner = stateMachine.PickupRadar.currentPickUpSpawner.GetPickup();
            if (currentPickupSpawner != null) 
            {
                Debug.Log("StartSwitch");
                stateMachine.SwitchState(new HoldMotion(stateMachine,currentPickupSpawner));
            }
        }
    }

}
