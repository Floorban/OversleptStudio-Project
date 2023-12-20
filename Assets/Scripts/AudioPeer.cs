using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public float[] samples = new float[512];
    public float[] freqBand = new float[8];
    public float[] bandBuffer = new float[8];
    float[] bufferDecrese = new float[8];

    public float g1;
    public float g2;
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }
    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i ++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j ++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 7;
        }
    }
    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (freqBand[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrese[g] = g1;
            }
            if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrese[g];
                bufferDecrese[g] *= g2;
            }
        }
    }
}
