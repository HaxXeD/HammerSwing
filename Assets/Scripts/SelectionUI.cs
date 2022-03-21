using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    LevelUI level;
    public CanvasGroup background;
    public void OnEnable(){
        
        background.alpha = 0;
        gameObject.transform.localPosition = new Vector3(Screen.width+100,0,0);
        background.LeanAlpha(1,0.5f);
        // gameObject.LeanScale(new Vector3(1,1,1),0.5f).setEaseOutExpo().delay = 0.1f;
        gameObject.LeanMoveLocalX(0,0.5f).setEaseInQuad().delay = 0.1f;

    }

    public void OnClose(){
            gameObject.LeanMoveLocalX(Screen.width+100,0.5f).setEaseInQuad().setOnComplete(OnComplete);
            background.LeanAlpha(0,0.5f);
    }

    void OnComplete(){
        gameObject.SetActive(false);
    }
}
