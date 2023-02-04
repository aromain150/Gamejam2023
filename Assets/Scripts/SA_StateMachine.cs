using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SA_StateMachine : MonoBehaviour
{
    State currentState;
    
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
