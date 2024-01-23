using System.Collections;
using GG.Infrastructure.Utils.Swipe;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    public AudioSource audio;
    public GameManager gameManager;
    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }
    private void OnSwipe(string swipe)
    {
        if (swipe.StartsWith("U") && gameManager.canP)
        {
            audio.pitch += 0.07f;
        }
        if (swipe.StartsWith("D") && gameManager.canP)
        {
            audio.pitch -= 0.07f;
        }
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
