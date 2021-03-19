using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    
    
    void playSong() {
    
      audioSource.PlayOneShot(audioClip,13);
    }
}
