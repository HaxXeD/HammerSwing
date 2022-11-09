using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject SettingsUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject LevelCompleteUI;


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

    public GameObject GetSettingsUI()
    {
        return SettingsUI;
    }

    public GameObject GetGameOverUI(){
        return GameOverUI;
    }

    public GameObject GetPauseUI(){
        return PauseUI;
    }
    
    public GameObject GetLevelCompleteUI(){
        return LevelCompleteUI;
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
