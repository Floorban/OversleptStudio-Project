using UnityEngine;

public class AnimSpeed : MonoBehaviour
{
    [SerializeField] Animator mainAnimator;
    [SerializeField]
    private float animSpeedControl, factor;
    public AudioSource audioSource;

    public StickControl stick;
    private void Start()
    {
            mainAnimator = GetComponent<Animator>();
            mainAnimator.SetFloat("animSpeed", 0.5f);
            mainAnimator.SetBool("animStyle", false);
            audioSource = FindObjectOfType<AudioSource>();
            stick = GameObject.FindWithTag("Player").GetComponent<StickControl>();
            factor = 2.5f;
    }
    void Update()
    {
        if (stick.firstStart)
        {
            mainAnimator.SetBool("animStart", true);

            animSpeedControl = audioSource.pitch * factor;
            mainAnimator.SetFloat("animSpeed", animSpeedControl - 1f);
            mainAnimator.SetBool("animStyle", true);
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
