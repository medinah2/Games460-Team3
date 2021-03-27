using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour
{
    
    public AudioSource buttonFX;
    public AudioClip clickFX;
<<<<<<< HEAD
    public static float buttonVolume = 9;
    
    public void clickSound() {
      buttonFX.PlayOneShot(clickFX,buttonVolume);
=======
    
    public void clickSound() {
      buttonFX.PlayOneShot(clickFX);
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
    
    }
    
}
