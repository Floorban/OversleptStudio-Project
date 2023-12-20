using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParameter : MonoBehaviour
{
    AudioSource audioSource;
    AudioReverbFilter audioEditor;
    float sliderValue;
    float sliderValue2;
    float sliderValue3;

    void Start()
    {
        sliderValue = 0.5f;
        //sliderValue2 = 0.1f;
        sliderValue2 = 0.2f;
        sliderValue3 = 0.1f;
        audioSource = GetComponent<AudioSource>();
        audioEditor = GetComponent<AudioReverbFilter>();
        audioSource.Play();
    }

    void OnGUI()
    {
        sliderValue = GUI.HorizontalSlider(new Rect(630, 350, 300, 300), sliderValue, 0.0F, 10F);
        //sliderValue2 = GUI.HorizontalSlider(new Rect(25, 100, 300, 100), sliderValue2, 0.1F, 1.5F);
       // sliderValue3 = GUI.HorizontalSlider(new Rect(25, 175, 300, 100), sliderValue3, 0.1F, 10.0F);
        //audioSource.pitch = sliderValue;
      //  audioSource.volume = sliderValue2;
        audioEditor.decayTime = sliderValue;

    }
}
