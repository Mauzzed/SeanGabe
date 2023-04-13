//using Sean;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//namespace Sean 
//{ 

//}



//public class MovementScript : MonoBehaviour
//{
//    private PlayerControls input = null;
//    private Vector2 moveVector = Vector2.zero;
//    private Rigidbody2D rb = null;
//    private Vector2 moveSpeed;

//    //private float moveSpeed = 10f;

//    private void Awake()
//    {
//        input = new PlayerControls();
//        rb = GetComponent<Rigidbody2D>();
//    }
//     public void Move(InputAction.CallbackContext context)
//    {
//        horizontal = context.ReadValue<Vector2>().x;
//    }
//    private void OnEnable()
//    {
//        input.OnEnable();
//        input.PlayerControl.Movement.performed += OnMovementPerformed;
//        input.PlayerControl.Movement.canceled += OnMovementCancelled;
//    }
//    private void OnDisable()
//    {
//        input.OnDisable();
//        input.PlayerControl.Movement.performed -= OnMovementPerformed;
//        input.PlayerControl.Movement.canceled -= OnMovementCancelled;
//    }
//    private void FixedUpdate()
//    {
//        rb.velocity = moveVector * moveSpeed;
//    }



//    private void OnMovementPerformed(InputAction.CallbackContext value)
//    {
//        moveVector = value.ReadValue<Vector2>();
//    }
//    private void OnMovementCancelled(InputAction.CallbackContext value)
//    {
//        moveVector = Vector2.zero;
//    }

//}



