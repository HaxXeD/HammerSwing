using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Throw : MonoBehaviour
{
    ListAudio listAudio;
    public event System.Action OnCollision;
    Rigidbody2D rb;
    Revolve revolve;
    Vector3 tangent;
    bool isThrown;
    float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        revolve = GetComponent<Revolve>();
        tangent =  revolve.ReturnTangent();
        speed = revolve.ReturnSpeed();
        revolve.enabled = false;
        listAudio = FindObjectOfType<ListAudio>();
    }

    void FixedUpdate()
    {        
        if (!isThrown)
        {
            rb.AddForce(tangent * speed / 10, ForceMode2D.Impulse);
            isThrown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            rb.drag = Mathf.SmoothDamp(0,1,ref speed,3);
            listAudio.PlaySound(3);
            OnCollision?.Invoke();
            StartCoroutine(PlayClaps(0.5f));
            StartCoroutine(ReloadScene(6.5f));
        }
    }

    IEnumerator ReloadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     IEnumerator PlayClaps(float time)
    {
        yield return new WaitForSeconds(time);
        listAudio.PlaySound(0);
    }

    
}
