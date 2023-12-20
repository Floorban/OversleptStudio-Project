using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamObj : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public AudioPeer audioPeer;
    public bool useBuffer;
    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }
    void Update()
    {
     
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, 
                                                                                  (audioPeer.bandBuffer[band] * scaleMultiplier) + startScale,
                                                                                  transform.localScale.z);

            Color color = new Color(audioPeer.bandBuffer[band], audioPeer.bandBuffer[band], audioPeer.bandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        }else
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                                                                  (audioPeer.freqBand[band] * scaleMultiplier) + startScale,
                                                                                  transform.localScale.z);
        }
    }
}
