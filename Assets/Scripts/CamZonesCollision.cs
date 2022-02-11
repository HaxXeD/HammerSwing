using Cinemachine;
using UnityEngine;
public class CamZonesCollision : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCameraInsideBound = null;
    [SerializeField] CinemachineVirtualCamera virtualCameraOutsideBound = null;
    
    private void Start()
    {
        virtualCameraInsideBound.Priority = 1;
        virtualCameraOutsideBound.Priority = 1;
        print(virtualCameraInsideBound.enabled);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ball"))
        {
            virtualCameraInsideBound.Priority = 2;
            virtualCameraOutsideBound.Priority = 1;
            print(virtualCameraInsideBound.enabled);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ball"))
        {
            virtualCameraInsideBound.Priority = 1;
            virtualCameraOutsideBound.Priority = 2;
            print(virtualCameraInsideBound.enabled);
        }
    }
}


