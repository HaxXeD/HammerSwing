using Cinemachine;
using UnityEngine;

public class CamZonesTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCameraInsideBound = null;
    [SerializeField] CinemachineVirtualCamera virtualCameraOutsideBound = null;

    private void Start()
    {
        virtualCameraInsideBound.Priority = 1;
        virtualCameraOutsideBound.Priority = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            virtualCameraInsideBound.Priority = 2;
            virtualCameraOutsideBound.Priority = 1 ;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            gameObject.SetActive(false);
            virtualCameraInsideBound.Priority = 1;
            virtualCameraOutsideBound.Priority = 2;
        }
    }
}


