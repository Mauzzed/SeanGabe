using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    PlayerControls controls;
    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();

        controls.Newactionmap.Move.performed += ctx => movement = ctx.ReadValue<Vector2>(); // player movement code
        controls.Newactionmap.Move.canceled += ctx => movement = Vector2.zero;         //vector2(0,0)
        Debug.Log(movement);


   

    }
    private void FixedUpdate()
    {
        Move(movement);
    }
    private void Move(Vector2 moveDir)
    {
        rb.AddForce(moveDir);

    }
     
}