using UnityEngine;

public class SettingButtons : MonoBehaviour
{
    Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();  
    }

    public void ShowSettingsUI()
    {
        settings.GetSettingsUI().SetActive(true);
    }

    public void HideSettingsUI()
    {
        settings.GetSettingsUI().SetActive(false);
    }

    public void ShowGameOverUI(){
        settings.GetGameOverUI().SetActive(true);
    }

    public void HideGameOverUI(){
        settings.GetGameOverUI().SetActive(false);
    }
    public void ShowLevelCompleteUI(){
        settings.GetLevelCompleteUI().SetActive(true);
    }
    public void HideLevelCompleteUI(){
        settings.GetLevelCompleteUI().SetActive(false);
    }
}
