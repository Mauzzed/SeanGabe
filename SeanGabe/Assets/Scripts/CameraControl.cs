/*****************************************************************************
// File Name :         CameraControl.cs
// Author :            Gabriel Holmes
// Creation Date :     April 27, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform Player;
    public float dampTime = 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    /// <summary>
    /// This function is to control where the camera is and who it follows. We have
    /// set it to follow the transform(Or players location) and also have a bit of 
    /// camera lag time so it feels faster.
    /// </summary>
    void Update()
    {
        cameraPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
    }
}
