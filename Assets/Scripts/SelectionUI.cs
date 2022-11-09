using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    LevelUI level;
    [SerializeField] CanvasGroup backgroundImage;
    [SerializeField] GameObject countrySelection;
    [SerializeField] GameObject home;




    public void OnEnable(){
        countrySelection.transform.localScale = Vector3.zero;  
        gameObject.transform.localPosition = new Vector3(Screen.width+200,0,0); 
        home.transform.localPosition = Vector3.zero; 
        backgroundImage.alpha = 0;
        home.transform.LeanMoveLocalX(-Screen.width-200,0.5f).setEaseInQuad().setOnComplete(ActiveSelectionScreen).delay = 0.1f;
        gameObject.LeanMoveLocalX(0,0.5f).setEaseInQuad().setOnComplete(OnSet);   
        // gameObject.LeanScale(new Vector3(1,1,1),0.5f).setEaseOutExpo().delay = 0.1f;
              
    }
    void ActiveSelectionScreen(){ 
        backgroundImage.LeanAlpha(1,.5f);
        home.SetActive(false);
    }

    void OnSet(){
        countrySelection.LeanScale(Vector3.one,0.5f).setEaseInQuad().delay = 0.1f;
    }

    public void OnClose(){ 
        home.SetActive(true);       
        countrySelection.LeanScale(Vector3.zero,0.5f).setOnComplete(OnComplete).delay = 0.1f;    
        backgroundImage.LeanAlpha(0,.5f).setOnComplete(ActiveHomeScreen);     
    }

    void OnComplete(){  
        gameObject.LeanMoveLocalX(Screen.width+200,0.5f).setEaseInQuad();        
        gameObject.SetActive(false);
    }
    void ActiveHomeScreen(){
        home.transform.LeanMoveLocalX(0,0.5f).setEaseInQuad(); 
    }


}
