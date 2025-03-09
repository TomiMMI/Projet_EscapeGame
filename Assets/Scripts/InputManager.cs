using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerControlMaps playerControlMaps;

    public event EventHandler OnInteractInputReceived;
    public event EventHandler OnInteractAlternateInputReceived;
    public event EventHandler OnSprintInputActivated;
    public event EventHandler OnSprintInputDisactivated;

    void Awake()
    {
        Instance = this;
        playerControlMaps = new PlayerControlMaps();
        playerControlMaps.Enable();
        playerControlMaps.FPSPlayingMap.Interact.performed += Interact_performed;
        playerControlMaps.FPSPlayingMap.InteractAlternate.performed += InteractAlternate_performed;
        playerControlMaps.FPSPlayingMap.Sprint.started += Sprint_started;
        playerControlMaps.FPSPlayingMap.Sprint.canceled += Sprint_canceled;
    }

    private void Start()
    {
    }

    private void Sprint_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSprintInputActivated?.Invoke(this, EventArgs.Empty);
    }

    private void Sprint_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSprintInputDisactivated?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateInputReceived?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractInputReceived?.Invoke(this, EventArgs.Empty);
    }





    public Vector2 GetMoveInputValues()
    {
        return playerControlMaps.FPSPlayingMap.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookDirection()
    {
        return playerControlMaps.FPSPlayingMap.Look.ReadValue<Vector2>();
    }
    public void EnableFPSPlayingMap()
    {
        playerControlMaps.FPSPlayingMap.Enable();
    }
    public void DisableFPSPlayingMap()
    {
        playerControlMaps.FPSPlayingMap.Disable();
    }
}