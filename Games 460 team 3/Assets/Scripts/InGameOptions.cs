using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptions : MonoBehaviour
{
    
    public GameObject optionsButton;
    
    void Start() {
     
     // Cursor.lockState = CursorLockMode.None;
     optionsButton = GameObject.FindGameObjectWithTag("OptionsBut");
     optionsButton.SetActive(true);
    }
    
    void Update() {
    /*
      Debug.Log(optionsButton);
      if (Input.GetKey(KeyCode.O)) {
        optionsButton.SetActive(true);
      }
      if (Input.GetKey(KeyCode.X)) {
        optionsButton.SetActive(false);
      }
    }
    */
    }
    
    public void testFunction() {
      backToMenuButton.goToMainMenu();
    }
    
   
}
