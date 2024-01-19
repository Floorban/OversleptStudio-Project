using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SpawnButton : MonoBehaviour
{
    private Animator SpawnButtonAnimator;
    
    [SerializeField]
    private int ID;
    private bool Clicked;
    public void SetID(int _ID)
    {
        ID = _ID;
        SpawnButtonAnimator.SetInteger("Image ID", _ID);
    }

    public void ClickedButton(bool _Clicked)
    {
        SpawnButtonAnimator.SetBool("Clicked", Clicked);
    }
    int x;
    float finalNum;
    private void Start()
    {
        SpawnButtonAnimator = GetComponent<Animator>();

    }

    private void Update()
    {

    }

    private bool AnimatorIsPlaying(int layer, string stateName)
    {
        if (SpawnButtonAnimator.GetCurrentAnimatorStateInfo(layer).IsName(stateName) && SpawnButtonAnimator.GetNextAnimatorStateInfo(layer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
