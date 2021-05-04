using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public static Slider slider;
    
   
    
    private float targetProgress = 0; 
    
    public static float newProgress = 0; 
    
    public float fillSpeed = 0.5f;
    
    private void Awake() {
      slider = gameObject.GetComponent<Slider>();
      
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        newProgress = 0;
        //incProgressValue(newProgress);
    }

    // Update is called once per frame
    void Update()
    {
        //incProgressValue(newProgress);
        //if (slider.value < 5) {
         // slider.value += fillSpeed + Time.deltaTime;
        //}
       // Debug.Log("Slider val " + slider.value);
    }
    
    public static void incProgressValue(float newProgress) {
        
        slider.value = newProgress;
        
        
    
    
    }
}
