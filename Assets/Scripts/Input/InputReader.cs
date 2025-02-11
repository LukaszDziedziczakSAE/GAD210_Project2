using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    Controls controls;

    public event Action LeftClickPress;
    public event Action LeftClickRelease;
    public bool LeftClickDown {  get; private set; }
    public Vector2 MousePosition { get; private set; }
    public event Action PauseMenuPress;

    private void Awake()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LeftClickDown = true;
            LeftClickPress?.Invoke();
        }
        else if (context.canceled)
        {
            LeftClickDown = false;
            LeftClickRelease?.Invoke();
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }

    public void OnPauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed) PauseMenuPress?.Invoke();
    }
}
