using UnityEngine;

public class PerformerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("animSpeed", 0.5f);
        animator.SetFloat("animStyle", 0.2f);
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float move_amount = Mathf.Clamp01(Mathf.Abs(movement.x) + Mathf.Abs(movement.z));
        animator.SetFloat("animSpeed", move_amount, 100f, 1f);
        animator.SetFloat("animStyle", move_amount, 100f, 1f);

    }
}
