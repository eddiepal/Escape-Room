﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Look Sensitivity")]
    public float sensX; 
    public float sensY;
 
    [Header("Clamping")]
    public float minY;
    public float maxY;
 
    private float rotX;
    private float rotY;

    private Gamepad gamepad = Gamepad.current;
    private PlayerInputActions inputAction;
    private Vector2 cameraInput;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        PlayerInput.playerInput.controls.PlayerControls.MoveCamera.performed +=
            ctx => cameraInput = ctx.ReadValue<Vector2>();
    }

    void Start ()
    {
        // lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate ()
    {
        rotX += cameraInput.x * sensX;
        rotY += cameraInput.y * sensY;

        if (!PauseMenu.gamePaused && !GameChat.chatIsOpen)
        {
            rotX += Input.GetAxis("Mouse X") * sensX;
            rotY += Input.GetAxis("Mouse Y") * sensY;
        }


        
        rotY = Mathf.Clamp(rotY, minY, maxY);
        
        // rotate the camera vertically
        transform.localRotation = Quaternion.Euler(-rotY, 0, 0);
 
        // rotate the player horizontally
        transform.parent.rotation = Quaternion.Euler(transform.rotation.x, rotX, 0);
        
        // Account for scaling applied directly in Windows code by old input system.
        //cameraInput *= 0.5f;
        // Account for sensitivity setting on old Mouse X and Y axes.
        //cameraInput *= 0.1f;
    }
}
