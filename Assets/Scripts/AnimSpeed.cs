using UnityEngine;

public class AnimSpeed : MonoBehaviour
{
    [SerializeField] Animator mainAnimator;
    [SerializeField, Range(0f, 1.5f)] float animSpeedControl = 0.5f;
    [SerializeField, Range(0f, 1.5f)] float animVolumeControl = 0.5f;

    public AudioSource audioSource;
    [SerializeField]
    private float audioSpeed, audioVolume;
    [SerializeField]
    private float factor, factor2;
    private void Start()
    {
        mainAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        audioSpeed = audioSource.pitch;
        animSpeedControl = audioSpeed * factor;
        mainAnimator.SetFloat("animSpeed", animSpeedControl, 100f, 1f);

        audioVolume = audioSource.volume;
        animVolumeControl = audioVolume * factor2;
        mainAnimator.SetFloat("animStyle", animVolumeControl, 100f, 1f);
    }
}
