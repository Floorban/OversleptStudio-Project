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

    [SerializeField]
    private int volumeLevel, pitchLevel, moveLevel;
    [SerializeField]
    private TextMeshProUGUI volumeText, pitchText, moveText;

    [SerializeField]
    private Image countDownBar;
    [SerializeField]
    private float countTimer;
    private void Start()
    {
        countTimer = 10f;
    }
    private void Update()
    {
        text.text = startTime.ToString("0.00");

        if (collider1Hit || collider2Hit)
        {
            startTime += Time.deltaTime;
        }

        if (collider1Hit && collider2Hit)
        {  
            text.color = Color.green;
            collider1Hit = false;
            collider2Hit = false;
        }

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
        if (countTimer == 10f)
        {
            volumeLevel = Random.Range(0, 10);
            pitchLevel = Random.Range(0, 10);
            moveLevel = Random.Range(0, 10);

            volumeText.text = $"Volume: + {volumeLevel.ToString()}";
            pitchText.text = $"Pitch: + {pitchLevel.ToString()}";
            moveText.text = $"Movement: + {moveLevel.ToString()}";
        }
    }
    private void CountDownBar()
    {
        countDownBar.fillAmount = countTimer / 10f;

        countTimer -= Time.deltaTime;

        if (countTimer <= 0f)
        {
            countTimer = 10f;
        }
    }
}

