using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    SettingButtons settingButtons;
    public event System.Action<GameState> OnStateChange;
    public GameState state;
    private static GameManager _instance;
    public static GameManager Instance{get{return _instance;}}

    private void Awake()
    {
        if (_instance!=null &&_instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start(){
        UpdateGameState(GameState.StartGame);
    }

    public void UpdateGameState(GameState newState){
        state = newState;
        switch (newState){
            case GameState.StartGame:
            break;

            case GameState.SelectLevel:
            break;            

            case GameState.LevelStart:
            break;

            case GameState.LevelComplete:
            break;

            case GameState.LevelFailed:
            break;   

            case GameState.End:
            break;

            default:
            throw new System.Exception();
        }
        OnStateChange?.Invoke(newState);
    }
}

public enum GameState{
    StartGame,
    SelectLevel,
    LevelStart,
    LevelComplete,
    LevelFailed,
    End
}

