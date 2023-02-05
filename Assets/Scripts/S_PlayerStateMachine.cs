using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class S_PlayerStateMachine : SA_StateMachine
{
    [field : SerializeField] public S_InputReader inputReader { get; private set; }
    [field : SerializeField] public S_Movement movement { get; private set; }
    [field : SerializeField] public NavMeshAgent agent { get; private set; }
    [field : SerializeField] public S_PickupPoint PickUpPoint { get; private set; }
    [field : SerializeField] public S_PickupRadar PickupRadar { get; private set; }
    [field : SerializeField] public S_Interact interact { get; private set; }
    [field : SerializeField] public float defaultSpeed { get; private set; }

    public SO_Pickup currentPickup;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new NoMotion(this)); 
    }

    public SO_Pickup LoosePickup()
    {
        SO_Pickup tempPickup = currentPickup;
        currentPickup = null;
        PickUpPoint.RemoveModel();
        SwitchState(new FreeMotion(this));
        return tempPickup;
    }
}
