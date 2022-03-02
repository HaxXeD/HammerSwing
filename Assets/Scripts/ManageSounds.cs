using UnityEngine;

public class ManageSounds : MonoBehaviour
{
    ListAudio listAudio;
    // Start is called before the first frame update
    void Start()
    {
        listAudio = FindObjectOfType<ListAudio>();
    }
    public void PlayButtonSound(int _index){
        listAudio.PlaySound(_index);
    }
}
