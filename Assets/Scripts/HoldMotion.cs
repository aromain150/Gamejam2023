using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldMotion : PlayerBaseState
{
    public HoldMotion(S_PlayerStateMachine stateMachine,SO_Pickup pickupItem) : base(stateMachine)
    {
        currentPickup = pickupItem;
    }

    SO_Pickup currentPickup; 


    public override void Enter()
    {
        //    stateMachine.PickUpPoint = currentPickup

        stateMachine.inputReader.ReleaseEvent += Release;

        stateMachine.PickUpPoint.AddModel(currentPickup.model);
    }

    public override void Exit()
    {
        stateMachine.inputReader.ReleaseEvent -= Release;
    }

    public override void Tick(float deltatime)
    {
        Move(deltatime);
    }

    public void Move(float deltatime)
    {
        stateMachine.movement.Move(stateMachine.inputReader.MovementValue);

    }

    public void Release()
    {
        stateMachine.interact.InteractWithTerrier(currentPickup.points);
        stateMachine.PickUpPoint.RemoveModel();
        stateMachine.SwitchState(new FreeMotion(stateMachine));
    }
}
