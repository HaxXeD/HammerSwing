using UnityEngine;
using UnityEngine.UI;

public class scrollingBackground : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform ground;

    [SerializeField] private RawImage _imgBackground;
    [SerializeField] private RawImage _imgForegraound;
    [SerializeField]private Vector2 _positionBackground = new Vector2(1,1);
    [SerializeField]private Vector2 _positionForeground = new Vector2(1,1);

    [SerializeField]private float _dividingFactorBackground = 50f;
    [SerializeField]private float _dividingFactorForeground = 30f;
    [SerializeField]private float _dividingFactorForeground_Y = 30f;

    private Vector2 _scale = new Vector2(1,1);

    float _intCameraSize;
    float _camera_xPos;
    float _camera_yPos;

    private Camera _camera;
    private void Awake(){
        _camera = Camera.main;
        ball = GameObject.FindGameObjectWithTag("ball").transform;
        ground  = GameObject.FindGameObjectWithTag("ground").transform;
    }

    private void Start(){
        _intCameraSize = _camera.orthographicSize;
        _camera_xPos = _camera.transform.position.x;
        _camera_yPos = _camera.transform.position.y;
    }
    // Update is called once per frame
    void Update(){
        float _changedSize_Background =(_camera.orthographicSize - _intCameraSize)/_dividingFactorBackground+1;
        float _changed_xPos_Background = (_camera.transform.position.x - _camera_xPos)/_dividingFactorBackground;
        float _changed_yPos_Background = (_camera.transform.position.y - _camera_yPos)/_dividingFactorBackground;

        float _changedSize_Foreground =(_camera.orthographicSize - _intCameraSize)/_dividingFactorForeground+1;
        float _changed_xPos_Foreground = (_camera.transform.position.x - _camera_xPos)/_dividingFactorForeground;

        float _changed_ball_yPos =(ball.position.y - ground.position.y)/_dividingFactorForeground_Y;

        _imgBackground.uvRect = new Rect(new Vector2(_positionBackground.x * _changed_xPos_Background,_positionBackground.y*_changed_yPos_Background),_scale*_changedSize_Background);
        _imgForegraound.uvRect = new Rect(new Vector2(_positionForeground.x * _changed_xPos_Foreground,_positionForeground.y*_changed_ball_yPos),_scale*_changedSize_Foreground);
    }
}
