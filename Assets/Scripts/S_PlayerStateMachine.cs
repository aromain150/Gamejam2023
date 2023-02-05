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


    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new NoMotion(this)); 
    }
}
