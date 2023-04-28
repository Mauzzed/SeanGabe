/*****************************************************************************
// File Name :         JumpScript.cs
// Author :            Sean Forrester
// Creation Date :     April 13, 2023
//
// Brief Description :This Scripts contains player movement functionality
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

    private float horizontal;
<<<<<<< Updated upstream
    private readonly float speed = 8f;
    private readonly float jumpingPower = 16f;
    private bool isFacingRight = true;
=======
    public float speed = 8f;
    public float jumpingPower = 16f;
>>>>>>> Stashed changes

    public Vector3 Vector2 { get; private set; }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

    }
    /// <summary>
    /// This code controls the input system jump functionality as well as functioning
    /// as a groundcheck
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
    private bool IsGrounded()
    {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, grounfLayer);
    }

    private bool IsBox()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, pntObjectLayer);
    }


   
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2  = transform.localScale;
    }

    //this code reads the controller inputs for movement

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
