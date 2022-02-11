using UnityEngine;
using TMPro;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField] Transform ballPos;
    [SerializeField] Transform startPos;

    TMP_Text Distance;

    bool startMeasurement = false;
    bool startTracking;

    private void Start()
    {
        Distance = GetComponent<TMP_Text>();

        FindObjectOfType<Revolve>().OnLaunch += Starting;
        FindObjectOfType<Throw>().OnCollision += Ending;
    }

    private void FixedUpdate()
    {
        if (startTracking)
        {
            float distance;
            if (startMeasurement)
            {
                distance = (ballPos.position.x - startPos.position.x)/10f;
                Distance.text = distance.ToString() + "m";
            }
            Distance.transform.position = new Vector2(ballPos.position.x, Distance.transform.position.y);
        }
      
    }

    private void Ending()
    {
        startMeasurement = false;
    }

    private void Starting()
    {
        startTracking = true;
        startMeasurement = true;
    }
}
