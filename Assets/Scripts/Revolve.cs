using UnityEngine;

public class Revolve : MonoBehaviour
{
    public event System.Action OnLaunch;

    //Reference to Throw.cs to enable it
    Throw throwBall;

    [Range(0, 480)]
    [SerializeField] float speed;

    int i = 0;
    float angle1;
    float angle2;
    float difference;

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
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwBall.enabled = true;
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
            return;            
        }
        if (speed > 480)
        {
            speed = 240;
        }
        #endregion
    }
}
