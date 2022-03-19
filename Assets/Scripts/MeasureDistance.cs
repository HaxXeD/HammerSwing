using UnityEngine;
using TMPro;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField] Transform ballPos;
    [SerializeField] Transform startPos;

    TMP_Text Distance;

    bool startMeasurement = false;
    float distance;

    private void Start()
    {
        Distance = GetComponent<TMP_Text>();
        
        FindObjectOfType<Revolve>().OnLaunch += Starting;
        FindObjectOfType<Throw>().OnCollision += Ending;
    }

    private void FixedUpdate()
    {
        if(startMeasurement){
            distance = (ballPos.position.x - startPos.position.x)/10f;    
            Distance.text = distance.ToString() + "m";  
        }    
    }

    private void Ending()
    {
        startMeasurement = false;
    }

    private void Starting()
    {
        startMeasurement = true;
    }

    private void OnDisable(){
        FindObjectOfType<Revolve>().OnLaunch -= Starting;
        FindObjectOfType<Throw>().OnCollision -= Ending;
    }
}
