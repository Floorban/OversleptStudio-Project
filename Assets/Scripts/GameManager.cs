using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool collider1Hit, collider2Hit;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private TextMeshProUGUI text;
    private int hitTimes = 0;

    [SerializeField]
    private float volumeLevel, pitchLevel, moveLevel;
    [SerializeField]
    private TextMeshProUGUI volumeText, pitchText, moveText;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private Image countDownBar;
    [SerializeField]
    private float countTimer;
    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
        countTimer = 15f;
    }
    private void Update()
    {
        text.text = startTime.ToString("0.0");

        if (collider1Hit || collider2Hit)
        {
            startTime += Time.deltaTime;
        }

        if (collider1Hit && collider2Hit)
        {  
            text.color = Color.green;
            collider1Hit = false;
            collider2Hit = false;
            hitTimes++;
        }

        CheckValue();
        RandomTask();
        CountDownBar();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!collider1Hit && !collider2Hit)
        {
            collider1Hit = true;
            startTime = 0f;
            text.color = Color.white;
        }
        else if (collider1Hit && !collider2Hit)
        {
            collider2Hit = true;
        }
    }

    private void RandomTask()
    {
        if (countTimer == 15f)
        {
            volumeLevel = Mathf.Round(Random.Range(0.3f, 1.0f) * 10.0f) / 10.0f;
            pitchLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;
            moveLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;

            volumeText.text = $"Volume: {volumeLevel.ToString()}";
            pitchText.text = $"Pitch: {pitchLevel.ToString()}";
            moveText.text = $"Movement: {moveLevel.ToString()}";

            volumeText.color = Color.white;
            pitchText.color = Color.white;
            moveText.color = Color.white;

            hitTimes = 0;
            //transform.position = new Vector3(0, 0, 0);
        }
    }
    private void CheckValue()
    {
        if (audio.volume == volumeLevel)
        {
            volumeText.color = Color.green;
        }

        if (audio.pitch == pitchLevel)
        {
            pitchText.color = Color.green;
        }

        if (Mathf.Abs(startTime - moveLevel) <= 0.5f && hitTimes >= 3)
        {
            moveText.color = Color.green;
        }
    }
    private void CountDownBar()
    {
        countDownBar.fillAmount = countTimer / 15f;

        countTimer -= Time.deltaTime;

        if (countTimer <= 0f)
        {
            countTimer = 15f;
        }
    }

    public void PitchUp()
    {
        audio.pitch += 0.1f;
    }

    public void PitchDown()
    {
        audio.pitch -= 0.1f;
    }
}

