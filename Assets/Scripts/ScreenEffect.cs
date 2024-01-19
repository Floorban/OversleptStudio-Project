using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material screenMat;
    public float factor;
    void Start()
    {
       
    }

    void Update()
    {
        screenMat.SetFloat("_FullscreenIntensity", factor);
    }
}
