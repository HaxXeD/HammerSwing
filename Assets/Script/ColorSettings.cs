using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ColorSettings : MonoBehaviour
{
    float valueToLerp;
    Slider brightnessSlider;
    Slider contrastSlider;
    Slider saturationSlider;
    private Volume v;
    private ColorAdjustments setting;

    private ChromaticAberration chromatic;  
    private LensDistortion lensDistortion;

    private Vignette vignette;
    Settings colourSettings;
    private void Awake()
    {
        colourSettings = FindObjectOfType<Settings>();
        brightnessSlider = colourSettings.GetBrightness();
        contrastSlider = colourSettings.GetContrast();
        saturationSlider = colourSettings.GetSaturation();        
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if(state == GameState.LevelStart){
            chromatic.intensity.value = 0;
            lensDistortion.intensity.value = 0;
            vignette.intensity.value =0;
            FindObjectOfType<Revolve>().OnLaunch+=Boom;
            FindObjectOfType<Throw>().OnCollision+=Disss;
        }
    }

    private void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet<ColorAdjustments>(out setting);
        v.profile.TryGet<ChromaticAberration>(out chromatic);
        v.profile.TryGet<LensDistortion>(out lensDistortion);
        v.profile.TryGet<Vignette>(out(vignette));

        brightnessSlider.maxValue = 1f;
        brightnessSlider.minValue = -2f;

        contrastSlider.maxValue = 100f;
        contrastSlider.minValue = -50f;

        saturationSlider.maxValue = 100f;
        saturationSlider.minValue = -100f;

        if (PlayerPrefs.HasKey("Brightness"))
        {
            setting.postExposure.value = brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
            setting.contrast.value = contrastSlider.value = PlayerPrefs.GetFloat("Contrast");
            setting.saturation.value = saturationSlider.value = PlayerPrefs.GetFloat("Saturation");
        }
        else
        {
            setting.postExposure.value = brightnessSlider.value = 0f;
            setting.contrast.value = contrastSlider.value = 0f;
            setting.saturation.value = saturationSlider.value = 0f;
        }
    }

    public void resetColour()
    {
        setting.postExposure.value = brightnessSlider.value = 0.01194698f;
        setting.contrast.value = contrastSlider.value = 0.83559f;
        setting.saturation.value = saturationSlider.value = 35.4568f;
    }

    public void Update()
    {
        setting.postExposure.value = brightnessSlider.value;
        setting.contrast.value = contrastSlider.value;
        setting.saturation.value = saturationSlider.value;     
        GameManager.Instance.OnStateChange+=GameManagerOnGameStateChanged;   
    }


    private void Save()
    {
        PlayerPrefs.SetFloat("Brightness", setting.postExposure.value);
        PlayerPrefs.SetFloat("Saturation", setting.saturation.value);
        PlayerPrefs.SetFloat("Contrast", setting.contrast.value);
    }

    private void Boom(){
        StartCoroutine(LerpChrome(0,0.5f,1));
        StartCoroutine(LerpLens(0,-0.1f,1));
        StartCoroutine(LerpVignette(0,0.2f,1));
    }   
    private void Disss(){
        StartCoroutine(LerpChrome(0.5f,0,4));
        StartCoroutine(LerpLens(-0.1f,0,4));
        StartCoroutine(LerpVignette(0.2f,0,4));
    }

    IEnumerator LerpChrome(float startValue, float endValue, float lerpDuration)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            chromatic.intensity.value = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        chromatic.intensity.value = endValue;
    }

    IEnumerator LerpLens(float startValue,float endValue, float lerpDuration)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            lensDistortion.intensity.value = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        lensDistortion.intensity.value = endValue;
    }

    IEnumerator LerpVignette(float startValue,float endValue, float lerpDuration)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            vignette.intensity.value = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        vignette.intensity.value = endValue;
    }
}
