using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    [SerializeField] CanvasGroup background;
    void OnEnable(){
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.zero;
        background.alpha = 0;
        background.LeanAlpha(1,0.5f);
        gameObject.LeanScale(Vector3.one,0.5f).setEaseInQuad().delay = 0.1f;

    }

    public void OnClose(){
        background.LeanAlpha(0,0.5f);
        gameObject.LeanMoveLocalY(-Screen.height,0.5f).setEaseInQuad().setOnComplete(AfterCompletion).delay = .1f;
    }

    void AfterCompletion(){
        gameObject.SetActive(false);
    }
}
