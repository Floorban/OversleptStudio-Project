using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    private Touch touch;
    [SerializeField]
    private float speed;
    private mSpawner spawner;
    void Start()
    {
        speed = -0.008f;
        spawner = FindObjectOfType<mSpawner>();
    }

    private void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                                                                                  transform.position.y,
                                                                                  transform.position.z + touch.deltaPosition.y * speed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.currentNum--;
        Destroy(gameObject);
    }
}
