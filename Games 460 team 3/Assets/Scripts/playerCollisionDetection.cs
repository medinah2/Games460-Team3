using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisionDetection : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter(Collider collision) {
        
        if (collision.gameObject.tag == "Evidence") {
            Debug.Log("goes in");
            
            ProgressBar.newProgress += 1.0f;
            
            ProgressBar.incProgressValue(ProgressBar.newProgress);
           
          
        }
    }

    
}
