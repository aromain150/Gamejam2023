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

        stateMachine.inputReader.AttackEvent += Release;

        stateMachine.PickUpPoint.AddModel(currentPickup.model);
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltatime)
    {
        
    }

    public void Release()
    {
        stateMachine.PickUpPoint.RemoveModel();
        stateMachine.SwitchState(new FreeMotion(stateMachine));
    }
}
