using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour
{

    public AudioSource buttonFX;
    public AudioClip clickFX;
    public static float buttonVolume = 9;
    
    public void clickSound() {
      buttonFX.PlayOneShot(clickFX,buttonVolume);

    }

}
