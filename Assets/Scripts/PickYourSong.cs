using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickYourSong : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject pickSongCanvas;
    void Start()
    {
        menuCanvas.SetActive(true);
        pickSongCanvas.SetActive(false);
    }

    public void SongMenu()
    {
        menuCanvas.SetActive(false); 
        pickSongCanvas.SetActive(true);
            }
    public void GoBack()
    { 
        menuCanvas.SetActive(true);
        pickSongCanvas.SetActive(false);
    }

    void Update()
    {
        
    }
}
