using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    [SerializeField] CanvasGroup background;
    void OnEnable(){
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.zero;
        background.alpha = 0;
        gameObject.LeanScale(Vector3.one,0.5f).setEaseInQuad();
        background.LeanAlpha(3,0.5f);
    }
    public void OnClose(){
        background.LeanAlpha(0,0.5f).setOnComplete(AfterCompletion);        
    }

    void AfterCompletion(){
        gameObject.LeanMoveLocalY(-Screen.height,0.5f).setEaseInQuad().setOnComplete(SetInactive);
    }

    void SetInactive(){
        gameObject.SetActive(false);
    }
}
