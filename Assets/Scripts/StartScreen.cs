using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void FixedUpdate(){
        if(Input.GetKeyDown(KeyCode.Space)){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
