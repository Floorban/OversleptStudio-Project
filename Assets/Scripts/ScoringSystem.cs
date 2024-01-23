using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScoringSystem : MonoBehaviour
{
    public float currentPoint, addPoint;
    public Material wandMat;
    public Volume volume;
    public GameObject _particle;
    public Transform pos1, pos2;
    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        wandMat = renderer.material;
    }
    private void Update()
    {
        /*if (currentPoint >= 20f)
        {
            wandMat.EnableKeyword("_EMISSION");
            if (volume.profile.TryGet(out Bloom bloom))
            {
                bloom.intensity.value = 5f;
                bloom.scatter.value = 0.9f;
                bloom.clamp.value = 10f;
            }
        }else
        {
            wandMat.DisableKeyword("_EMISSION");
            if (volume.profile.TryGet(out Bloom bloom))
            {
                bloom.intensity.value = 1f;
                bloom.scatter.value = 0.1f;
                bloom.clamp.value = 0f;
            }
        }*/

    }
    public void Score()
    {
        currentPoint += 100;
        GameObject p1 = Instantiate(_particle, pos1.position, Quaternion.identity);
        GameObject p2 = Instantiate(_particle, pos2.position, Quaternion.identity);
        Destroy(p1, 2f);
        Destroy(p2, 2f);
    }
    public void LosePoint()
    {
        currentPoint -= 50;
    }
}
