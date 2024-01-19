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
    private float countTimer, duration;


    public mSpawner spawner;

    public GyroTest gyro;
    [SerializeField]
    private float volumeFactor;
    [SerializeField]
    private TextMeshProUGUI vText;
    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
        countTimer = duration;
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
        CheckWave();

        vText.text = gyro.angularVelocity.z.ToString("0.0");
        volumeFactor = gyro.angularVelocity.x;

        if (volumeFactor <= -2f)
        {
            audio.volume -= 0.1f;
        }else if (volumeFactor >= 2f)
        {
            audio.volume += 0.1f;
        }

        if (audio.pitch >= 1.2f)
        {
            audio.pitch = 1.2f;
        }else if (audio.pitch <= 0.8f)
        {
            audio.pitch = 0.8f;
        }

    
    }
    /*private void OnTriggerEnter(Collider other)
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
    }*/

    private void CheckWave()
    {
        if (gyro.angularVelocity.z <= -5f && !collider1Hit)
        {
            if (!collider2Hit)
            {
                collider1Hit = true;
                startTime = 0f;
                text.color = Color.white;
            }
     
        }else if (gyro.angularVelocity.z >= 5f && collider1Hit)
        {
            collider2Hit = true;
        }
    }
    private void RandomTask()
    {
        if (countTimer == duration)
        {
            /*volumeLevel = Mathf.Round(Random.Range(0.2f, 0.8f) * 10.0f) / 10.0f;
            pitchLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;
            moveLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;*/

            int v = Random.Range(2, 8);
            int p = Random.Range(8, 12);
            int m = Random.Range(8, 12);

            volumeLevel = (float) v / 10;
            pitchLevel = (float)p / 10;
            moveLevel = (float)m / 10;

            float targetVolume = volumeLevel;
            float adjustment = targetVolume - audio.volume;
            audio.volume += adjustment;

            float targetPitch = pitchLevel;
            float adjustmentp = targetPitch - audio.pitch;
            audio.pitch += adjustmentp;

            /*volumeText.text = $"Volume: {volumeLevel.ToString()}";
            pitchText.text = $"Pitch: {pitchLevel.ToString()}";*/
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
        if (audio.volume == 0.5f)
        {
            volumeText.color = Color.green;
        }else
        {
            //Debug.Log(audio.volume);
        }

        if (audio.pitch == 1)
        {
            pitchText.color = Color.green;
        }

        if (Mathf.Abs(startTime - moveLevel) <= 0.5f && hitTimes >= 2)
        {
            moveText.color = Color.green;
        }
    }
    private void CountDownBar()
    {
        countDownBar.fillAmount = countTimer / duration;

        countTimer -= Time.deltaTime;

        if (countTimer <= 0f)
        {
            countTimer = duration;
        }
    }

    public void PitchUp()
    {
        audio.volume += 0.1f;
    }

    public void PitchDown()
    {
        audio.volume -= 0.1f;
    }
}

