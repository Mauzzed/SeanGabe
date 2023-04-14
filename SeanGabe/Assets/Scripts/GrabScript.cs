/*****************************************************************************
// File Name :         DashScript.cs
// Author :            Gabriel Holmes
// Creation Date :     April 13, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabScript : MonoBehaviour
{

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    /// <summary>
    /// This function sets the layer index to Pick and Throw Objects or P.N.T
    /// </summary>/// <summary>
    /// This function sets the layer index to Pick and Throw Objects or P.N.T
    /// </summary>/// <summary>
    /// This function sets the layer index to Pick and Throw Objects or P.N.T
    /// </summary>
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("pntObject");
    }

    /// <summary>
    /// This function grabs the object by getting its position from the raycast.
    /// When the player presses the left trigger it will pick up the item make it 
    /// a static object and a child of the player so it moves with them. Once 
    /// released it will remove it as a child make it a movable object again and set
    /// grabbed object to false or null.
    /// </summary>
    public void Grab(InputAction.CallbackContext context)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {

            //grab object
            if (context.performed && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            //release object
            else if (context.canceled)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}

