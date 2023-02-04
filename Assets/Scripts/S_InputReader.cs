using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputReader : MonoBehaviour, Controls.IPlayerActions
{

    public Vector2 MovementValue{ get; private set; }

    public event Action AttackEvent;
    public event Action LookEvent;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        //controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        AttackEvent?.Invoke();
    }
}
