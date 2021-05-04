using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionSensiBar : MonoBehaviour
{
    public Slider optionMenuSensitivitySlider;
    //public static float mainMenuSensitivity;
    
    
    
    private void Awake() {
     optionMenuSensitivitySlider = gameObject.GetComponent<Slider>();
      
    }
    void Start()
    {
       optionMenuSensitivitySlider.value = mainMenuSensiSlider.mainMenuSensitivity; 
    }

    // Update is called once per frame
    void Update()
    {
       
       //mainMenuSensitivity = mainMenuSensitivitySlider.value;
       //Debug.Log("Testing: " + mainMenuSensitivity);
    }
}
