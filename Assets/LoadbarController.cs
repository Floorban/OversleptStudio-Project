using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadbarController : MonoBehaviour
{
    public GameObject doneTextholder;
    public Image loadbarForeground;
    public float timeRemaining;
    public float max_time = 5.0f;
    public GameObject loadbarTextHolder;

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
        else
        {
            doneTextholder.SetActive(true);
            loadbarTextHolder.SetActive(false);
        }

        if (timeRemaining >= max_time + 1f)
        {
            Debug.Log("lol");
            SceneManager.LoadScene(2);
        }

    }
}
