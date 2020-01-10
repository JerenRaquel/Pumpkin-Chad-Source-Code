using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    [Header("Settings")]
    [Range(0, .9f)]
    public float intensityLevelMin = .4f;
    [Range(0.1f, 1)]
    public float intensityLevelMax = .6f;
    public float increment = .05f;
    public float delay = .5f;

    private Vignette vignetteLayer;
    private float intensityLevel;

    private void Start() {
        postProcessVolume.profile.TryGetSettings(out vignetteLayer);
        intensityLevel = (intensityLevelMin + intensityLevelMax) / 2; 

        StartCoroutine(UpdateSettings());
    }

    private IEnumerator UpdateSettings() 
    {
        while(true)
        {
            intensityLevel += increment;

            if(intensityLevel >= intensityLevelMax - .05 || intensityLevel <= intensityLevelMin - .05f)
                increment *= -1;
            
            if(vignetteLayer != null)
            {
                vignetteLayer.intensity.value = intensityLevel;
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
