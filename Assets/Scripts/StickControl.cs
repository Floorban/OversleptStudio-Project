using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControl : MonoBehaviour
{
    public CameraChange camera;
    [SerializeField]
    private int stickID;
    [SerializeField]
    private GameObject stick2;
    public bool firstStart;

    public GameManager gameManager;
    private void Start()
    {
        stick2.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (stickID == 0)
        {
            if (!firstStart)
            {
                firstStart = true;
                gameManager.enabled = true;
            }

            camera.RotateUp();
            camera.ZoomOut();
            stick2.SetActive(true);
            stick2.transform.position = new Vector3(0.2f, -1.5f, -5f);
        }
        else if (stickID == 1)
        {
            //stick2.transform.position += new Vector3(gameManager.swingFactor, gameManager.volumeFactor, 0) * Time.deltaTime;
            camera.RotateDown();
            camera.ZoomIn();
            stick2.SetActive(false);
        }
    }
    private void OnMouseDrag()
    {
        if (stickID == 0)
        {
            if (!firstStart)
            {
                firstStart = true;
                gameManager.enabled = true;
            }

            camera.RotateUp();
            camera.ZoomOut();
            stick2.SetActive(true);
            stick2.transform.position = new Vector3(0.2f, -1.5f, -5f);
        }
        else if (stickID == 1)
        {
            //stick2.transform.position += new Vector3(gameManager.swingFactor, gameManager.volumeFactor, 0) * Time.deltaTime;
            camera.RotateDown();
            camera.ZoomIn();
            stick2.SetActive(false);
        }
    }

}
