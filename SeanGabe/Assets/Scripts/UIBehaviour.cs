/*****************************************************************************
// File Name :         UIBehavior.cs
// Author :            Gabriel Holmes
// Creation Date :     April 27, 2023
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIBehaviour : MonoBehaviour
{
/// <summary>
/// These three function send the buttons on the UI to their indivual screens
/// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("SeanGabe");
    }

    public void loadControls()
    {
        SceneManager.LoadScene("Controls");
    }
    
    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void inGameControls()
    {
        controls.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void backToGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void backToPause()
    {
        controls.SetActive(false);
        PauseMenu.SetActive(true);
    }
}  
