using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject resumeButton;
    public GameObject pauseButton;
    
    void Start()
    {
        pauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Pause() 
    {
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
            Time.timeScale = 0f;
       
    }

    public void Resume()
    {
       
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            Time.timeScale = 1f;
           
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
