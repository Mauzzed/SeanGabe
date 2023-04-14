/*****************************************************************************
// File Name :         CameraScript.cs
// Author :            Sean Forrester
// Creation Date :     April 13, 2023
//
// Brief Description :This script is for camera functionality
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this code makes the camera follow the player
/// </summary>
public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Update()
    {
        transform.position = target.position + offset;
    }
}
