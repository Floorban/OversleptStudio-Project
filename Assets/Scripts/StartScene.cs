using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float timer, endTIme;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private CameraChange cam;
    [SerializeField]
    private GameObject guideBook, endBook;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private float scoreLerpDuration;
    [SerializeField]
    private ScoringSystem score;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private StickControl stick;
    [SerializeField]
    private GameObject volume;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Open");
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= endTIme)
        {
            Invoke("EndGame", 0f);
            timer = -1000000f;
        }
    }

    private void EndGame()
    {
        audio.Stop();
        stick.firstStart = false;
        volume.SetActive(false);
        cam.RotateDown();
        cam.ZoomIn();
        guideBook.SetActive(false);
        endBook.SetActive(true);
        gameManager.enabled = false;
        //text.text = $"Score: { score.currentPoint }";
        StartCoroutine(LerpScoreText(score.currentPoint));
    }
    private IEnumerator LerpScoreText(float targetScore)
    {
        float elapsedTime = 0f;
        float startScore = 0f;

        while (elapsedTime < scoreLerpDuration)
        {
            float lerpedScore = Mathf.Lerp(startScore, targetScore, elapsedTime / scoreLerpDuration);
            text.text = $"Score: {Mathf.RoundToInt(lerpedScore)}";

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.text = $"Score: {Mathf.RoundToInt(targetScore)}";
    }
}
