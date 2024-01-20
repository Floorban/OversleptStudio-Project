using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    public void WinEffect()
    {
       if (volume.profile.TryGet(out Vignette vignette))
        {
            if (vignette.intensity.value <= 1f && vignette.intensity.value >= 0f)
            {
                vignette.intensity.value -= 0.1f;
            }
        }
        if (volume.profile.TryGet(out ColorAdjustments color))
        {
            if (color.saturation.value <= 0f && color.saturation.value >= -100f)
            {
                color.saturation.value += 10f;
            }
        }
    }
    public void FailEffect()
    {
        if (volume.profile.TryGet(out Vignette vignette))
        {
            if (vignette.intensity.value <= 1f && vignette.intensity.value >= 0f)
            {
                vignette.intensity.value += 0.1f;
            }
        }
        if (volume.profile.TryGet(out ColorAdjustments color))
        {
            if (color.saturation.value <= 0f || color.saturation.value >= -100f)
            {
                color.saturation.value -= 10f;
            }
        }
    }
}
