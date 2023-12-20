using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private Transform sphere;
    private float scale;
    void Awake()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere = go.transform;

        // create a yellow quad
        go = GameObject.CreatePrimitive(PrimitiveType.Quad);
        go.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
        go.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        go.GetComponent<Renderer>().material.color = new Color(0.75f, 0.75f, 0.0f, 0.5f);

        scale = 0.1f;
    }

    void OnGUI()
    {
        Vector3 pos = sphere.position;
        pos.y += Input.mouseScrollDelta.y * scale;
        sphere.position = pos;
    }
}
