using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("animSpeed", 0.5f);
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float move_amount = Mathf.Clamp01(Mathf.Abs(movement.x) + Mathf.Abs(movement.z));
        animator.SetFloat("animSpeed", move_amount, 100f, 1f);

        /*if (move_amount > 0)
        {
            Quaternion target_rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, 100f * Time.deltaTime);
        }*/
    }
}
