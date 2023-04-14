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
    private readonly float speed = 8f;
    private readonly float jumpingPower = 16f;

    public Vector3 Vector2 { get; private set; }


    // Update is called once per frame
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
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
