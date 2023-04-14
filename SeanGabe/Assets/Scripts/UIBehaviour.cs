using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}  
