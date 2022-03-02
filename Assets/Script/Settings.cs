using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject UI;

    [SerializeField] Slider brightnessSlider;
    [SerializeField] Slider contrastSlider;
    [SerializeField] Slider saturationSlider;

    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        GetCamera();
    }


    private void Update()
    {
        if (canvas.worldCamera == null)
        {
            GetCamera();
        }
    }
    public void GetCamera()
    {
        canvas.worldCamera = Camera.main;
    }

    public GameObject GetUI()
    {
        return UI;
    }
    public Slider GetBrightness()
    {
        
        return brightnessSlider;
    }

    public Slider GetContrast()
    {
        return contrastSlider;
    }

    public Slider GetSaturation()
    {
        return saturationSlider;
    }
}
