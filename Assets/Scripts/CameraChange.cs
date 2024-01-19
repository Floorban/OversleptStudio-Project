using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    public void ZoomIn()
    {
        StartCoroutine(LerpFieldOfView(cam.fieldOfView, cam.fieldOfView - 20f, 0.3f));
    }
    public void ZoomOut()
    {
        StartCoroutine(LerpFieldOfView(cam.fieldOfView, cam.fieldOfView + 20f, 0.3f));
    }

    public void RotateUp()
    {
        StartCoroutine(LerpRotation(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(35f, 0f, 0f)), 0.2f));
    }

    public void RotateDown()
    {
        StartCoroutine(LerpRotation(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(35f, 0f, 0f)), 0.2f));
    }

    IEnumerator LerpFieldOfView(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cam.fieldOfView = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cam.fieldOfView = endValue;
    }

    IEnumerator LerpRotation(Quaternion startRotation, Quaternion endRotation, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
    }
}