using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Open");
    }

}
