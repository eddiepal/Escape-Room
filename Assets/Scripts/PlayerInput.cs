using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActions controls;
    public static PlayerInput playerInput;
    
    private void Awake()
    {
        playerInput = this;
        controls = new PlayerInputActions();

    }
    
    public void OnEnable()
    {
        controls.Enable();
    }

/*
    public void OnDisable()
    {
        controls.Disable();
    }
    */

    public void EnablePlayerControls()
    {
        controls.PlayerControls.Enable();
    }

    public void DisablePlayerControls()
    {
        controls.PlayerControls.Disable();
    }
}
