using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldMotion : PlayerBaseState
{
    public HoldMotion(S_PlayerStateMachine stateMachine,SO_Pickup pickupItem) : base(stateMachine)
    {
        stateMachine.currentPickup = pickupItem;
    }
 
    public override void Enter()
    {
        //    stateMachine.PickUpPoint = currentPickup

        stateMachine.agent.speed = stateMachine.defaultSpeed - stateMachine.currentPickup.heaviness;
        stateMachine.inputReader.ReleaseEvent += Release;

        stateMachine.PickUpPoint.AddModel(stateMachine.currentPickup.model);

        stateMachine.modelHandler.SetHolding();
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
        stateMachine.interact.InteractWithTerrier(stateMachine.currentPickup.points);
        stateMachine.PickUpPoint.RemoveModel();
        stateMachine.currentPickup = null;
        stateMachine.SwitchState(new FreeMotion(stateMachine));
    }
}
