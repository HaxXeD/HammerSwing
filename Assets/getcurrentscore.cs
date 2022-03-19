using UnityEngine;
using TMPro;
public class getcurrentscore : MonoBehaviour
{
    TMP_Text _thisText;
    TMP_Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _thisText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText = GameObject.FindWithTag("score").GetComponent<TMP_Text>();
        _thisText = _scoreText;
    }
}
