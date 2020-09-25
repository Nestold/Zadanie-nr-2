using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBobbing : MonoBehaviour
{
    private Light2D light;
    public float indexer = 0.1f, start, stop;
    private void Start()
    {
        light = GetComponent<Light2D>(); 
        StartCoroutine(Bobbing());
    }

    private IEnumerator Bobbing()
    {
        yield return new WaitForSeconds(0.1f);

        if (light.pointLightOuterRadius > stop || light.pointLightOuterRadius < start)
            indexer *= -1;
        light.pointLightOuterRadius += indexer;
        StartCoroutine(Bobbing());
    }
}
