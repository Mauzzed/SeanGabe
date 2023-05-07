/*****************************************************************************
// File Name :         JumpScript.cs
// Author :            Gabriel Holmes
// Creation Date :     April 27, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask grounfLayer;
    public LayerMask pntObjectLayer;

    public GameObject PauseMenu;

    private float horizontal;
    private readonly float speed = 8f;
    private readonly float jumpingPower = 16f;

    public Vector3 Vector2 { get; private set; }


    /// <summary>
    /// This Update function sets the speed of the player
    /// </summary>
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal < 0)
        {
            transform.localRotation = new Quaternion(0, -180, 0, 0);
        }
        else if (horizontal > 0f)
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

    }

    /// <summary>
    /// This function calls the jump input from InputManager and sets the jump to be
    /// different heights based on the pressure applied to the A button(Or Space)
    /// </summary>
    /// <param name="context"></param>
    public void Jump(InputAction.CallbackContext context)
    {
        if ( context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (context.performed && IsBox())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    /// <summary>
    /// Sets player to ground and returns this to the raycast set below the player
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, grounfLayer);
    }

    /// <summary>
    /// Raycast finds position of boxers
    /// </summary>
    /// <returns></returns>
    private bool IsBox()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, pntObjectLayer);
    }
    /// <summary>
    /// This calls the left joystick from the input manager for movement
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
}
