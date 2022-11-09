using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class Revolve : MonoBehaviour
{
    SettingButtons settingButtons;
    ListAudio listAudio;
    SceneLoader sceneLoader;
    TMP_Text counter;
    Image fillGauge;
    public event System.Action OnLaunch;

    //Reference to Throw.cs to enable it
    Throw throwBall;

    [Range(0, 480)]
    [SerializeField] float speed;

    int i = 0;
    float angle1;
    float angle2;
    float difference;
    float initAngle;
    float addedFill =0;
    float newFill = 0;
    bool loopRunnig;
    bool gameOverUIShown;

    Vector3 tangent;

    public Vector3 ReturnTangent()
    {
        return tangent;
    }

    public float ReturnSpeed()
    {
        return speed;
    }

    [SerializeField] Transform target;

    private void Awake(){
        fillGauge = GameObject.FindGameObjectWithTag("fill").GetComponent<Image>();
        counter = GameObject.FindGameObjectWithTag("counter").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        speed = 300;
        throwBall = GetComponent<Throw>();   
        listAudio = FindObjectOfType<ListAudio>();
        settingButtons = FindObjectOfType<SettingButtons>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        initAngle = transform.rotation.eulerAngles.z;
        fillGauge.fillAmount = 0.095f;
        loopRunnig = true;
    }

    private void Initial(){
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GameManager.Instance.state == GameState.LevelStart){
            if (Input.GetKey(KeyCode.Space)){
                angle1 = transform.rotation.eulerAngles.z;
                transform.RotateAround(target.transform.position,Vector3.forward, speed * Time.deltaTime);
                angle2 = transform.rotation.eulerAngles.z;
                difference = angle2 - angle1;
            }           
        
            else if(Input.GetKeyUp(KeyCode.Space)){
                throwBall.enabled = true;
                listAudio.PlaySound(6);
                StartCoroutine(PlayClaps(1.5f));
                OnLaunch?.Invoke();
            }
        }


        else if(GameManager.Instance.state == GameState.LevelFailed){
            
            if(!gameOverUIShown){
                settingButtons.ShowGameOverUI();
                gameOverUIShown = true;
                print(gameOverUIShown);
            }    
        }
    
        if(Input.GetKeyDown(KeyCode.Space)&&gameOverUIShown){ 
            settingButtons.HideSettingsUI();
            settingButtons.HidePauseUI();
            settingButtons.HideGameOverUI(); 
            gameOverUIShown = false;
            print(gameOverUIShown);     
            sceneLoader.Reload();
        }

   

    //Calculations for Tangent
    #region

        Vector3 displacement = target.position - transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 t1 = Vector3.Cross(direction, Vector3.forward);
        Vector3 t2 = Vector3.Cross(direction, Vector3.up);
        if (t1.magnitude > t2.magnitude)
            tangent = t1;
        else
            tangent = t2;
    
    #endregion


        //Calculation for number of turns and incrementing speed
        #region
        if(loopRunnig)
        {
            float angleDifference  = angle1 - initAngle;
            addedFill = (angleDifference/360)/8;
            fillGauge.fillAmount = newFill + addedFill;         
        }

        if ((speed > 0) && (difference<0))
        {
            ++i;
            newFill = fillGauge.fillAmount;         
            
            print(i);
            counter.text = i.ToString();
            listAudio.PlaySound(2);
            if(i<=3){
                speed += 60;
            }
            else if(i>3){
                speed -=60;
            } 
            return; 
        }

        if (i >= 6)
        {               
            //Conditions left to experiment, for now kept basic.
            loopRunnig = false;
            fillGauge.fillAmount = 0f;
            i = 0;
            GameManager.Instance.UpdateGameState(GameState.LevelFailed);
        }
        #endregion


    }
    IEnumerator PlayClaps(float waitTime){
        yield return new WaitForSeconds(waitTime);
        listAudio.PlaySound(4);
    }
}
