/*****************************************************************************
// File Name :         DashScript.cs
// Author :            Gabriel Holmes
// Creation Date :     April 13, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    /// <summary>
    /// This function sets the win screen as active
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("WinScreen");
    }
}
