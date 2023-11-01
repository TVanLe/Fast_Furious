using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("-----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip-----------")]
    public AudioClip background;
    public AudioClip fall;
    public AudioClip wallTouch;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip portIn;
    public AudioClip portOut;

    public void Start() {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    

}
