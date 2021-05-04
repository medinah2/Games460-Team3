using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensitivityManager : MonoBehaviour
{
    private static GameObject ManagerInstance;
    public float playerSensitivity = 9.0f;
    public float audioVolume = 0.10f;
    
    
    void Awake() {
      DontDestroyOnLoad(this.gameObject);
      if (ManagerInstance != null) {
         Destroy(ManagerInstance);
        
         
      }
       ManagerInstance = this.gameObject;
    
    }
    void Start()
    {
    //DontDestroyOnLoad(this.gameObject);
    
    
    }

    // Update is called once per frame
   


    public void AdjustSensitivity(float newSensitivity) {
     playerSensitivity = newSensitivity;
    }

   public void AdjustVolume(float newVolume) {
    
     audioVolume = newVolume;

    }




}
