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
        settings.GetSettingsUI().GetComponent<SettingsBox>().CloseSetting();
    }

    public void ShowGameOverUI(){
        settings.GetGameOverUI().SetActive(true);
    }

    public void HideGameOverUI(){
        settings.GetGameOverUI().GetComponent<GameOverUI>().OnClose();
    }
    public void ShowLevelCompleteUI(){
        settings.GetLevelCompleteUI().SetActive(true);
    }
    public void HideLevelCompleteUI(){
        settings.GetLevelCompleteUI().GetComponent<LevelCompleteUI>().OnClose();
    }

    public void ShowPauseUI(){
        settings.GetPauseUI().SetActive(true);
    }

    public void HidePauseUI(){
        settings.GetPauseUI().GetComponent<PauseUI>().ClosePause();
    }

}
