using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void Reload(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
    public void LoadSceneIndex(int index){
        SceneManager.LoadScene(index);
    }
}
