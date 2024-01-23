using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClip : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    public AudioSource AudioSource => audio;

    //[SerializeField] private AudioClip song1, song2, song3, song4;

    public static ChangeClip instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (!audio) audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audio.enabled = true;
    }
    public void PlayClip(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
    /*public void AssignClip(int buttonID)
    {
        switch(buttonID)
        {
            case 0:
                audio.clip = song1;
                break;
            case 1:
                audio.clip = song2;
                break;
            case 2:
                audio.clip = song3;
                break;
            case 3:
                audio.clip = song4;
                break;
        }
        audio.Play();
    }*/
}
