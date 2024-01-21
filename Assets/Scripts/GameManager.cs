using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool collider1Hit, collider2Hit;
    [SerializeField]
    private float startTime;

    //private TextMeshProUGUI text;
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

    public GyroTest gyro;

    public float volumeFactor, swingFactor;
    [SerializeField]
    private TextMeshProUGUI vText;

    public bool canV, canP, canG, isV, isP, isG;
    [SerializeField]
    private GameObject tiltUI, pitchUI, swipeUI;
    [SerializeField] private int completedSwitches = 0;

    public CameraChange camera;

    public StickControl stick;

    public UnityEvent winEvent, failEvent;

    private float timer;
    public GameObject wand;
    private enum CountdownPeriod
    {
        Volume,
        Pitch,
        Gesture
    }
    private CountdownPeriod currentPeriod;
    private void Start()
    {
        if (stick.firstStart)
        {
            tiltUI.SetActive(false);
            pitchUI.SetActive(false);
            swipeUI.SetActive(false);

            currentPeriod = CountdownPeriod.Volume;
            audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
            countTimer = duration;
            RandomTask();
        }
     
    }
    private void Update()
    {
        if (stick.firstStart)
        {
            audio.enabled = true;
            // text.text = startTime.ToString("0.0");
            //vText.text = gyro.angularVelocity.z.ToString("0.0");
            volumeFactor = gyro.angularVelocity.x;
            swingFactor = -gyro.angularVelocity.x;

            if (swingFactor >= 0.65f)
            {
                swingFactor = 0.65f;
            }
            else if (swingFactor <= -0.6f)
            {
                swingFactor = -0.6f;
            }

            if (canG)
            {
                if (collider1Hit || collider2Hit)
                {
                    startTime += Time.deltaTime;
                }

                if (collider1Hit && collider2Hit)
                {

                    //text.color = Color.green;
                    collider1Hit = false;
                    collider2Hit = false;
                    hitTimes++;
                }

            }

            // tilt to change volume
            if (canV)
            {
                timer += Time.deltaTime;

                if (volumeFactor <= -1f && timer >= 0.5f)
                {
                    audio.volume -= 0.1f;
                    wand.transform.position += new Vector3(0, -0.5f, 0);
                    timer = 0f;
                }
                else if (volumeFactor >= 1f && timer >= 0.5f)
                {
                    audio.volume += 0.1f;
                    wand.transform.position += new Vector3(0,0.5f,0);
                    timer = 0f;
                }
            }

            switch (currentPeriod)
            {
                case CountdownPeriod.Volume:
                    canV = true;
                    canP = false;
                    canG = false;
                    break;
                case CountdownPeriod.Pitch:
                    canV = false;
                    canP = true;
                    canG = false;
                    break;
                case CountdownPeriod.Gesture:
                    canV = false;
                    canP = false;
                    canG = true;
                    break;
            }

            if (canV)
            {
                vText.text = "Volume!";
                tiltUI.SetActive(true);
                pitchUI.SetActive(false);
                swipeUI.SetActive(false);
            }
            else if (canP)
            {
                vText.text = "Pitch!";
                tiltUI.SetActive(false);
                pitchUI.SetActive(true);
                swipeUI.SetActive(false);
            }
            else if (canG)
            {
                vText.text = "Guide them!";
                tiltUI.SetActive(false);
                pitchUI.SetActive(false);
                swipeUI.SetActive(true);
            }

            CheckValue();
            if (completedSwitches == 3)
            {
                RandomTask();
            }
            CountDownBar();
            CheckGesture();
            LimitedPitch();
        }

     
    }
    private void RandomTask()
    {
        /*volumeLevel = Mathf.Round(Random.Range(0.2f, 0.8f) * 10.0f) / 10.0f;
      pitchLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;
      moveLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;*/

             int v = Random.Range(2, 8);
             int p = Random.Range(8, 12);
            int m = Random.Range(8, 12);

            volumeLevel = (float)v / 10;
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
            //moveText.text = $"Movement: {moveLevel.ToString()}";

        /*volumeText.color = Color.white;
        pitchText.color = Color.white;
        moveText.color = Color.white;*/

        vText.color = Color.red;

            hitTimes = 0;
            completedSwitches = 0;
            //transform.position = new Vector3(0, 0, 0);

    }
    private void CheckValue()
    {
        if (audio.volume == 0.5f)
        {
            volumeText.color = Color.green;
            if (canV)
            {
                Vibration.Vibrate(50);
                isV = true;
            }
        }
        else
        {
            volumeText.color = Color.red;
            isV = false;
        }

         if (audio.pitch == 1)
        {
            pitchText.color = Color.green;
            if (canP)
            {
                Vibration.Vibrate(50);
                isP = true;
            }
        }
        else
        {
            pitchText.color = Color.red;
            isP = false;
        }

         if (hitTimes >= 4)
        {
            moveText.color = Color.green;
            if (canG)
            {
                Vibration.Vibrate(50);
                isG = true;
            }
        }
        else
        {
            moveText.color = Color.red;
            isG = false;
        }
    }

    private void CheckGesture()
    {
        if (canG)
        {
            if (gyro.angularVelocity.z <= -3f && !collider1Hit)
            {
                if (!collider2Hit)
                {
                    collider1Hit = true;
                    startTime = 0f;
                    //text.color = Color.white;
                }

            }
            else if (gyro.angularVelocity.z >= 3f && collider1Hit)
            {
                collider2Hit = true;
            }

            wand.transform.position = new Vector3(-swingFactor * Time.deltaTime, -1.5f, -5f);
        }
    }
    private void CountDownBar()
    {
        countDownBar.fillAmount = countTimer / duration;

        countTimer -= Time.deltaTime;

        if (countTimer <= 0f)
        {
            if (isV || isP || isG)
            {
                winEvent.Invoke();
            }else if (!isV && !isP && !isG)
            {
                failEvent.Invoke();
            }

            wand.transform.position = new Vector3(0.2f, -1.5f, -5f);
            isV = false;
            isP = false;
            isG = false;
            Vibration.Cancel(); 
            hitTimes = 0;
            countTimer = duration;
            completedSwitches++;

            volumeText.color = Color.red;
            pitchText.color = Color.red;
            moveText.color = Color.red;

            // Switch to the next countdown period
            switch (currentPeriod)
            {
                case CountdownPeriod.Volume:
                    currentPeriod = CountdownPeriod.Pitch;
                    break;
                case CountdownPeriod.Pitch:
                    currentPeriod = CountdownPeriod.Gesture;
                    break;
                case CountdownPeriod.Gesture:
                    currentPeriod = CountdownPeriod.Volume;
                    break;
            }
        }

      
    }
    private void LimitedPitch()
    {
        if (audio.pitch >= 1.2f)
        {
            audio.pitch = 1.2f;
        }
        else if (audio.pitch <= 0.8f)
        {
            audio.pitch = 0.8f;
        }
    }

}

