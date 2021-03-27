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
        //Debug.Log("Volume: " + Music.volume);
    }


    public void AdjustSensitivity(float newSensitivity) {
     movement.sensitivity = newSensitivity;
    }

    public void AdjustVolume(float newVolume) {
      Music.volume = newVolume;
      buttonSound.buttonVolume = newVolume;

    }




}
