using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] GameObject Vfx;
    Vector2 tap;
    // Start is called before the first frame update
    void Start()
    {
        Vfx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
    }

    void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = Camera.main.ScreenToWorldPoint(Input.tapPosition);
            Vfx.SetActive(true);
            Vfx.transform.position = new Vector3(tap.x, tap.y, 0f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vfx.SetActive(false);
        }
        //if (Input.touchcount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    tap = Camera.main.ScreenToWorldPoint(touch.position);
        //    Vfx.SetActive(true);
        //    Vfx.transform.position = new Vector3(tap.x, tap.y, 0f);
        //}
        //else
        //{
        //    Vfx.SetActive(false);
        //}
    }
}
