using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuSensiSlider : MonoBehaviour
{
    public Slider mainMenuSensitivitySlider;
    public static float mainMenuSensitivity;
    
    
    
    private void Awake() {
    mainMenuSensitivitySlider   = gameObject.GetComponent<Slider>();
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       mainMenuSensitivitySlider.value = movement.sensitivity;
       mainMenuSensitivity = mainMenuSensitivitySlider.value;
       Debug.Log("Testing: " + mainMenuSensitivity);
    }
}
