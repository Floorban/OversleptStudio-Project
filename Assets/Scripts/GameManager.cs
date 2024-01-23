using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    public CameraChange camera;
    public GyroTest gyro;

    public UnityEvent winEvent, failEvent;
    public GameObject wand;

    [SerializeField]
    private bool checkPoint1, checkPoint2;
    private float swingTime;
    public int hitTimes = 0;

    public float volumeLevel, pitchLevel, swingLevel;
    [SerializeField]
    private TextMeshProUGUI volumeText, pitchText, swingText; 

    [SerializeField]
    private Image countDownBar;
    [SerializeField]
    private GameObject barObj;
    [SerializeField]
    private float countTimer, duration;
    private float tiltTimer;

    [SerializeField]
    private float volumeFactor, swingFactor;
    public bool canV, canP, canG, isV, isP, isG;
    [SerializeField] 
    private int completedSwitches = 0;
    [SerializeField]
    private GameObject tiltUI, pitchUI, swipeUI;
    [SerializeField]
    private TextMeshProUGUI instructionText;

    public Light light1, light2, light3;
    public ScoringSystem score;

    private CountdownPeriod currentPeriod;
    private enum CountdownPeriod
    {
        Volume,
        Pitch,
        Gesture
    }
    private void Start()
    {
        tiltUI.SetActive(false);
        pitchUI.SetActive(false);
        swipeUI.SetActive(false);
        barObj.SetActive(true);
        currentPeriod = CountdownPeriod.Volume;
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
        audio.enabled = true;
        countTimer = duration;
        RandomTask();
    }
    private void Update()
    {
        volumeFactor = gyro.angularVelocity.x;
        swingFactor = -gyro.angularVelocity.x;

        SwitchStage();
        RandomPitch();
        CheckValue();
        CountDownBar();
        UIChange();
        if (completedSwitches == 3)
        {
            RandomTask();
        }
    }
    private void SwitchStage()
    {
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
    }
    private void RandomPitch()
    {
        if (canP && !isP)
        {
            if (audio.pitch <= 0.9f)
            {
                audio.pitch -= Time.deltaTime * 0.05f;
            }
            else
            {
                audio.pitch += Time.deltaTime * 0.05f;
            }
        }
    }
    private void RandomTask()
    {
        if (score.volume.profile.TryGet(out Bloom bloom))
        {
            bloom.intensity.value = 1f;
            bloom.scatter.value = 0.1f;
        }
        light1.color = Color.red;
           light2.color = Color.red;
           light3.color = Color.red;
        /*volumeLevel = Mathf.Round(Random.Range(0.2f, 0.8f) * 10.0f) / 10.0f;
           pitchLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;
           moveLevel = Mathf.Round(Random.Range(0.8f, 1.2f) * 10.0f) / 10.0f;*/
           wand.transform.position = new Vector3(0.2f, -1f, -5f);

            int v = Random.Range(2, 5);
            //int p = Random.Range(8, 10);
            int[] integers = new int[] {7, 8, 12, 13};
            int randValue = Random.Range(0, integers.Length);
            int p = integers[randValue];
            int m = Random.Range(8, 12);

            volumeLevel = (float)v / 10;
            //volumeLevel = 0.2f;
            pitchLevel = (float)p / 10;
            swingLevel = (float)m / 10;

            audio.volume = volumeLevel;
            audio.pitch = pitchLevel;
            hitTimes = 0;
            completedSwitches = 0;
    }
    private void CheckValue()
    {
        if (audio.volume >= 0.7f)
        {
            volumeText.color = Color.green;
            if (canV)
            {
                Vibration.Vibrate(50);
                isV = true;
                light1.color = Color.green;
            }
        }
        else
        {
            volumeText.color = Color.red;
            isV = false;
            light1.color = Color.red;
        }

         if (audio.pitch > 0.9f && audio.pitch < 1.1f)
        {
            pitchText.color = Color.green;
            if (canP)
            {
                Vibration.Vibrate(50);
                isP = true;
                light2.color = Color.green;
            }
        }
        else
        {
            pitchText.color = Color.red;
            isP = false;
            light2.color = Color.red;
        }

         if (hitTimes >= 3)
        {
            swingText.color = Color.green;
            if (canG)
            {
                Vibration.Vibrate(50);
                isG = true;
                light3.color = Color.green;
            }
        }
        else
        {
            swingText.color = Color.red;
            isG = false;
            light3.color = Color.red;
        }

        LimitedValue();
        CheckTilt();
        CheckSwing();
    }
    private void CheckTilt()
    {
        // tilt to change volume
        if (canV)
        {
            //tiltTimer += Time.deltaTime;
            if (!isV)
            {
                audio.volume -= Time.deltaTime * 0.15f;
                wand.transform.position += new Vector3(0, -audio.volume * 0.13f, 0);

                /*if (volumeFactor <= -1f && tiltTimer >= 0.5f)
                {
                    audio.volume -= 0.1f;
                    wand.transform.position += new Vector3(0, -0.5f, 0);
                    tiltTimer = 0f;
                }*/

                if (volumeFactor >= 1f) //&& tiltTimer >= 0.25f
                {
                    audio.volume += 0.07f;
                    wand.transform.position += new Vector3(0, 0.25f, 0);
                    //tiltTimer = 0f;
                }
            }

        }
    }
    private void CheckSwing()
    {
        if (canG)
        {
            if (checkPoint1 || checkPoint2)
            {
                swingTime += Time.deltaTime;
            }

            if (checkPoint1 && checkPoint2)
            {
                checkPoint1 = false;
                checkPoint2 = false;
                hitTimes++;
                winEvent.Invoke();
            }

            if (gyro.angularVelocity.z <= -3f && !checkPoint1)
            {
                if (!checkPoint2)
                {
                    checkPoint1 = true;
                    swingTime = 0f;
                }

            }
            else if (gyro.angularVelocity.z >= 3f && checkPoint1)
            {
                checkPoint2 = true;
            }

            wand.transform.position = new Vector3(-swingFactor  * 0.7f, -1.5f, -5f);
        }
    }
    private void CountDownBar()
    {
        countDownBar.fillAmount = countTimer / duration;
        countTimer -= Time.deltaTime;

        if (score.volume.profile.TryGet(out Bloom bloom))
        {
            bloom.intensity.value = 1f;
            bloom.scatter.value = 0.1f;
        }

        if (countTimer <= 0f)
        {
            if (score.volume.profile.TryGet(out Bloom bloom2))
            {
                bloom2.intensity.value = 1f;
                bloom2.scatter.value = 0.1f;
            }

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
            swingText.color = Color.red;

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
    private void UIChange()
    {
        if (canV)
        {
            instructionText.text = "Volume!";
            tiltUI.SetActive(true);
            pitchUI.SetActive(false);
            swipeUI.SetActive(false);
            if (audio.volume > 0.5f)
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
            if (audio.volume >= 0.7f)
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
        }
        else if (canP)
        {
            instructionText.text = "Pitch!";
            tiltUI.SetActive(false);
            pitchUI.SetActive(true);
            swipeUI.SetActive(false);

            float adjustP = audio.pitch - 1f;

            if (Mathf.Abs(adjustP) <= 0.3f )
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
            if (Mathf.Abs(adjustP) <= 0.1f)
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
        }
        else if (canG)
        {
            instructionText.text = "Guide them!";
            tiltUI.SetActive(false);
            pitchUI.SetActive(false);
            swipeUI.SetActive(true);
            if (hitTimes >= 1)
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
            if (hitTimes >= 2)
            {
                if (score.volume.profile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value += 4f;
                    bloom.scatter.value += 0.4f;
                }
            }
        }
    }
    private void LimitedValue()
    {
        if (audio.pitch >= 1.5f)
        {
            audio.pitch = 1.5f;
        }
        else if (audio.pitch <= 0.5f)
        {
            audio.pitch = 0.5f;
        }

        if (swingFactor >= 0.65f)
        {
            swingFactor = 0.65f;
        }
        else if (swingFactor <= -0.6f)
        {
            swingFactor = -0.6f;
        }

        if (volumeFactor <= 0f)
        {
            volumeFactor = 0f;
        }

        if (audio.volume <= 0.1f)
        {
            audio.volume = 0.1f;
        }
    }

}

