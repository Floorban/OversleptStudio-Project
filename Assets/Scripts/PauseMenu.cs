using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void Pause() 
    {
        if (isPaused == false)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void Resume()
    {
        if (isPaused == true)
        {
            isPaused = false;   
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
