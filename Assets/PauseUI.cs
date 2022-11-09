using UnityEngine;

public class PauseUI : MonoBehaviour
{  
    [SerializeField] Transform box;
    [SerializeField] CanvasGroup background;

    private void OnEnable(){
        background.alpha = 0;
        background.LeanAlpha(1,0.5f);

        box.localPosition = new Vector2(0,-Screen.height);
        box.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void ClosePause(){
        background.LeanAlpha(0,0.5f);
        box.LeanMoveLocalY(-Screen.height,0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    private void OnComplete(){
        gameObject.SetActive(false);
    }
}
