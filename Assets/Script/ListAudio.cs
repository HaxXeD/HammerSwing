using System.Collections.Generic;
using UnityEngine;

public class ListAudio : MonoBehaviour
{
    AudioSource Source;
    AudioClip Clip;

   [SerializeField] List<AudioClip> gameSounds = new List<AudioClip>();

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        Clip = gameSounds[index];
        Source.clip = Clip;
        Source.PlayOneShot(Source.clip);
    }

    public void PlaySoundOnce(int index){
        Clip  = gameSounds[index];
        Source.clip = Clip;
        Source.Play();
    }

    public void OnHover(){
        PlaySoundOnce(1);
    }

    public void OnClick(){
        
    }
}
