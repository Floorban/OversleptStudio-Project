using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadbarController : MonoBehaviour
{
    public Image loadbarForeground;
    public float timeRemaining;
    public float max_time = 10f;
    public TextMeshProUGUI text;

    void Start()
    {
        timeRemaining = 0f;
    }

    void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining += Time.deltaTime;
            loadbarForeground.fillAmount = timeRemaining / max_time;
        }
        if (timeRemaining >= max_time + 1f)
        {
            SceneManager.LoadScene(2);
        }

        switch ((int)timeRemaining)
        {
            case 0:
                text.text = ("The audience is entering...");
                break;
            case 3:
                text.text = ("Putting on the performing suit...");
                break;
            case 6:
                text.text = ("Do you know that uConduct was made within one week...");
                break;
            /*case 6:
                text.text = ("Swipe the screen to change the pitch...");
                break;*/
            case 7:
                text.text = ("Looking for the music sheet and conducting wand...");
                break;
            case 10:
                text.text = ("Turning the phone to silent...");
                break;
        }

    }
}
