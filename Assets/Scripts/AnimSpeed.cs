using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSpeed : MonoBehaviour
{
    [SerializeField] Animator mainAnimator;
    [SerializeField, Range(5f, 10f)] float animSpeedControl = 0.5f;

    public AudioSource audioSource;
    [SerializeField]
    private float audioVolume;
    [SerializeField]
    private float factor;
    private void Start()
    {
        mainAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        audioVolume = audioSource.pitch;
        animSpeedControl = audioVolume * factor;

        mainAnimator.SetFloat("animSpeed", animSpeedControl, 10f, 1f);
    }
}
