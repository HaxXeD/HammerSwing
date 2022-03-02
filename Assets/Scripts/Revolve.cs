using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Revolve : MonoBehaviour
{
    ListAudio listAudio;
    [SerializeField] TMP_Text counter;
    [SerializeField] Image fillGauge;
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
    private void Start()
    {
        speed = 240;
        throwBall = GetComponent<Throw>();   
        listAudio = FindObjectOfType<ListAudio>();
        initAngle = transform.rotation.eulerAngles.z;
    }

private void Initial(){
    gameObject.SetActive(true);
}

    // Update is called once per frame
    async void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwBall.enabled = true;
            listAudio.PlaySound(6);
            StartCoroutine(PlayClaps(1.5f));
            OnLaunch?.Invoke();
        }

        //Calculations for Tangent
        #region
        Vector3 displacement = target.position - transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 t1 = Vector3.Cross(direction, Vector3.forward);
        Vector3 t2 = Vector3.Cross(direction, Vector3.up);
        if (t1.magnitude > t2.magnitude)
        {
            tangent = t1;
        }
        else
        {
            tangent = t2;
        }
        //print(direction);
        #endregion


        //Calculation for number of turns and incrementing speed
        #region
        angle1 = transform.rotation.eulerAngles.z;
        transform.RotateAround(target.transform.position,Vector3.forward, speed * Time.deltaTime);
        angle2 = transform.rotation.eulerAngles.z;
        difference = angle2 - angle1;
        if ((speed > 0) && (difference<0))
        {
            ++i;
            speed += 40;
            print(i);
            counter.text = i.ToString();
            listAudio.PlaySound(2);
            return;            
        }
        if (speed > 480)
        {
            speed = 240;
        }
        #endregion

        #region 
        for (int i = 0;i<7;i++){
            float angleDifference  = transform.eulerAngles.z - initAngle;
            fillGauge.fillAmount = angleDifference/360;
        }
        
        #endregion

    
        IEnumerator PlayClaps(float waitTime){
        yield return new WaitForSeconds(waitTime);
        listAudio.PlaySound(4);
    }
    }
}
