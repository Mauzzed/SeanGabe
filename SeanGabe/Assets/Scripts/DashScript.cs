/*****************************************************************************
// File Name :         DashScript.cs
// Author :            Gabriel Holmes
// Creation Date :     April 13, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashScript : MonoBehaviour
{
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;


    /// <summary>
    /// This function returns "is dashing" when the couritine finishes
    /// </summary>
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
    }
    /// <summary>
    /// Only Here to call Couroutine
    /// </summary>
    public void Dash(InputAction.CallbackContext context)
    {
        StartCoroutine(Dash());
    }

    /// <summary>
    /// sets can dash to falsh, is dashing is true. Turns gravity to 0. Then sets 
    /// the speed for the roll and the trail. THe dash then goes on cooldown.
    /// </summary>
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
