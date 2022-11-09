using UnityEngine;

public class LevelUI : MonoBehaviour
{
    SelectionUI selection;
    public GameObject countryUI;
    public GameObject backButton2;
    void OnEnable(){
        gameObject.transform.localPosition = new Vector3(Screen.width+200,0,0);
        gameObject.LeanMoveLocalX(0,0.5f).setEaseInQuad().delay = 0.1f;
        countryUI.LeanMoveLocalX(-Screen.width-200,0.5f).setEaseInQuad().setOnComplete(DisableCountry).delay = 0.1f;
        backButton2.SetActive(true);
    }

    // public void OnBack(bool state){
    //     if(state){
    //         countryUI.SetActive(true);
    //         gameObject.LeanMoveLocalX(Screen.width + 100,0.5f).setEaseInQuad().setOnComplete(DisableLevel).delay = 0.1f;
    //         countryUI.LeanMoveLocalX(0,0.5f).setEaseInQuad().delay = 0.1f;   
    //     }
             
    // }

    void DisableCountry(){
        countryUI.SetActive(false);
    }

    void DisableLevel(){
        gameObject.SetActive(false);
    }

    public void OnBack(){
        countryUI.SetActive(true);
        gameObject.LeanMoveLocalX(Screen.width+200,0.5f).setEaseInQuad().setOnComplete(DisableLevel).delay = 0.1f;
        countryUI.LeanMoveLocalX(0,0.5f).setEaseInQuad().delay = 0.1f;
        backButton2.SetActive(false);
    }

}
