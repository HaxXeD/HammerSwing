using UnityEngine;
public class EffectManager : MonoBehaviour
{
    ListAudio listAudio;
    float valueToLerp;
    void Awake()
    {
        GameManager.Instance.UpdateGameState(GameState.LevelStart);              
    }
    void Start(){
        listAudio = FindObjectOfType<ListAudio>();
        listAudio.PlaySound(5);
    }
}