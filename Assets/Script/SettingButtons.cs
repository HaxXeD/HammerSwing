using UnityEngine;

public class SettingButtons : MonoBehaviour
{
    Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();  
    }

    public void ShowUI()
    {
        settings.GetUI().SetActive(true);
    }

    public void HideUI()
    {
        settings.GetUI().SetActive(false);
    }
}
