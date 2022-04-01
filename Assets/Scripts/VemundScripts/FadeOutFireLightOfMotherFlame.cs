using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOutFireLightOfMotherFlame : MonoBehaviour
{
    public float startIntensity;
    public float endIntensity;
    public float dimTime;

    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float dimVelocity;

    private void Awake()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        dimVelocity = (endIntensity - startIntensity)/ dimTime;
    }

    private void OnEnable()
    {
        light2D.intensity = startIntensity;
        StartCoroutine(DimOverTime(dimTime));
    }

    private IEnumerator DimOverTime(float time)
    {
        Debug.Log(light2D.intensity);
        while (Mathf.Pow(light2D.intensity - endIntensity, 2) > 1e-3)
        {
            light2D.intensity += dimVelocity * Time.deltaTime;
            yield return null;
        }

        light2D.intensity = endIntensity;
    }

}
