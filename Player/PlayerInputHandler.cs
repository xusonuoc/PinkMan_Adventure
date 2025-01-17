﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }

    //[SerializeField]
    //private float inputHoldTime = 0.2f;
    //private float jumpInputStartTime;

    //private void Update()
    //{
    //    CheckJumpInputHoldTime(); 
    //}

    public void OnMoveInput(InputAction.CallbackContext context) 
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            JumpInput = true;
            //jumpInputStartTime= Time.time;

        }
    }

    public void UseJumpInput() => JumpInput = false;

    //private void CheckJumpInputHoldTime()
    //{
    //    if (Time.time >= jumpInputStartTime + inputHoldTime)
    //    {
    //        JumpInput = false;
    //    }
    //}

    // ------hướng dẫn sử dụng -------
    //public void OnMoveInput(InputAction.CallbackContext context)
    //{
    //    movementInput = context.ReadValue<Vector2>();
    //    Debug.Log(movementInput);
    //}
    //public void OnJumpInput(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        Debug.Log("Jump button pushes down now");
    //    }

    //    if (context.performed)
    //    {
    //        Debug.Log("Jump is being held down");
    //    }

    //    if (context.canceled)
    //    {
    //        Debug.Log("Jump button has been releases");
    //    }

    //    Debug.Log("Jump input");
    //}
}
