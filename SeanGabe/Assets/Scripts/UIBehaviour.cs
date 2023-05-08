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

    public GameObject controls;
    public GameObject PauseMenu;
/// <summary>
/// These functions send the buttons on the UI to their indivual screens
/// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
        
        Time.timeScale = 1;
    }

    public void loadControls()
    {
        SceneManager.LoadScene("Controls");
        Time.timeScale = 1;
    }
    
    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
<<<<<<< Updated upstream
=======
    public void Start1()
    {
        SceneManager.LoadScene("Lvl1");
        Time.timeScale = 1;
    }
    public void Start2()
    {
        SceneManager.LoadScene("Lvl2");
        Time.timeScale = 1;
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("SeanGabe");
        Time.timeScale = 1;
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The Button is working");
        Time.timeScale = 1;
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
>>>>>>> Stashed changes
}  
