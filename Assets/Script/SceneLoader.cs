using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int ReturnNextSene(){
        return SceneManager.GetActiveScene().buildIndex + 1;
    }

    public int ReturnCurrentScene(){
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(ReturnNextSene());
    }

    public void Reload(){
        SceneManager.LoadScene(ReturnCurrentScene());
    }

    public void Home()
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
