using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Throw : MonoBehaviour
{
    ListAudio listAudio;
    SceneLoader sceneLoader;
    SettingButtons settingButtons;
    public event System.Action OnCollision;
    Rigidbody2D rb;
    Revolve revolve;
    Vector3 tangent;
    bool isThrown;
    float speed;

    bool gameOverUIShown;
    bool levelCompleteUIShown;
    int nextScene;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        revolve = GetComponent<Revolve>();
        tangent =  revolve.ReturnTangent();
        speed = revolve.ReturnSpeed();
        revolve.enabled = false;
        listAudio = FindObjectOfType<ListAudio>();
        settingButtons = FindObjectOfType<SettingButtons>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        nextScene = sceneLoader.ReturnNextSene();
    }

    void FixedUpdate()
    {        
        if (!isThrown)
        {
            rb.AddForce(tangent * speed / 10, ForceMode2D.Impulse);
            isThrown = true;
        }
        if(GameManager.Instance.state == GameState.LevelFailed){
            
            if(!gameOverUIShown){
                settingButtons.ShowGameOverUI();
                gameOverUIShown = true;
            }    
        }
        else if(GameManager.Instance.state == GameState.LevelComplete){
            if(!levelCompleteUIShown){
                settingButtons.ShowLevelCompleteUI();
                levelCompleteUIShown = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){ 
            if(gameOverUIShown){
                settingButtons.HideGameOverUI(); 
                gameOverUIShown = false;
                sceneLoader.Reload();
            }
            else if(levelCompleteUIShown){
                settingButtons.HideLevelCompleteUI();
                levelCompleteUIShown = false;
                sceneLoader.PlayGame();
                if(nextScene>PlayerPrefs.GetInt("levelAt")){
                    PlayerPrefs.SetInt("levelAt",nextScene);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            rb.drag = Mathf.SmoothDamp(0,1,ref speed,3);
            listAudio.PlaySound(3);
            OnCollision?.Invoke();
            StartCoroutine(PlayClaps(0.5f));
            StartCoroutine(ReloadScene(6.5f));
        }

        if(collision.collider.tag == "endpoints"){
            GameManager.Instance.UpdateGameState(GameState.LevelFailed);
        }
    }

    IEnumerator ReloadScene(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.UpdateGameState(GameState.LevelComplete);

    }
     IEnumerator PlayClaps(float time)
    {
        yield return new WaitForSeconds(time);
        listAudio.PlaySound(0);
    }

    
}
