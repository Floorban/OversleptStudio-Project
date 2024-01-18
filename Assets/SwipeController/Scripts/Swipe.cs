using System.Collections;
using GG.Infrastructure.Utils.Swipe;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    public AudioSource audio;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
        audio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }
    private void OnSwipe(string swipe)
    {
        if (swipe.StartsWith("U"))
        {
            audio.volume += 0.1f;
        }
        if (swipe.StartsWith("D"))
        {
            audio.volume -= 0.1f;
        }
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
