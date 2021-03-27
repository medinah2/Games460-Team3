using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensitivityManager : MonoBehaviour
{
    
    float playerSensitivity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Sensitivity : " + movement.sensitivity);
<<<<<<< HEAD
        //Debug.Log("Volume: " + Music.volume);
=======
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
    }
    
   
    public void AdjustSensitivity(float newSensitivity) {
     movement.sensitivity = newSensitivity;
    }
    
<<<<<<< HEAD
    public void AdjustVolume(float newVolume) {
      Music.volume = newVolume;
      buttonSound.buttonVolume = newVolume;
    
    }
    
    
=======
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
    

}
