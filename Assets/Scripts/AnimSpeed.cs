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

    public GameObject clickEffect;

    public StickControl stick;
    private void Start()
    {
            mainAnimator = GetComponent<Animator>();
            mainAnimator.SetFloat("animSpeed", 0.5f);
            mainAnimator.SetFloat("animStyle", 0.2f);
    }
    void Update()
    {
        if (stick.firstStart)
        {
            mainAnimator.SetBool("animStart", true);

            audioSpeed = audioSource.pitch;
            animSpeedControl = audioSpeed * factor;
            mainAnimator.SetFloat("animSpeed", animSpeedControl, 100f, 1f);

            audioVolume = audioSource.volume;
            animVolumeControl = audioVolume * factor2;
            mainAnimator.SetFloat("animStyle", animVolumeControl, 100f, 1f);
        }


        /*float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            audioSource.pitch += 0.03f;
        }else if (scrollInput < 0f)
        {
            audioSource.pitch -= 0.03f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(clickEffect, transform.position, Quaternion.identity);
            audioSource.volume += 0.1f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(clickEffect, transform.position, Quaternion.identity);
            audioSource.volume -= 0.1f;
        }*/

    }
}
