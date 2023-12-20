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
        sliderValue = 1f;
        sliderValue2 = 0.1f;
        sliderValue3 = 0.1f;
        audioSource = GetComponent<AudioSource>();
        audioEditor = GetComponent<AudioReverbFilter>();
        audioSource.Play();
    }

    void OnGUI()
    {
        sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 300, 100), sliderValue, 0.0F, 1.0F);
        sliderValue2 = GUI.HorizontalSlider(new Rect(25, 100, 300, 100), sliderValue2, 0.1F, 2.0F);
        sliderValue3 = GUI.HorizontalSlider(new Rect(25, 175, 300, 100), sliderValue3, 0.1F, 20.0F);
        audioSource.pitch = sliderValue;
        audioEditor.decayHFRatio = sliderValue2;
        audioEditor.decayTime = sliderValue3;

    }
}
