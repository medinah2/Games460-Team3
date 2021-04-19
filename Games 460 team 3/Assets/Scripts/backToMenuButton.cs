using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenuButton : MonoBehaviour
{
    //public static var GameObject BackToMenu;
    //private var childObj : Transform;
    //public int test;
    
    public static GameObject menuButton; 
    public static GameObject Assassin;
   
   
    void Start()
    {
       
      if (AgentControl.menuSwitcher == 1) {
      menuButton = GameObject.FindGameObjectWithTag("MenuButtonOne");
       
      }
      if (AgentControl.menuSwitcher == 2) {
      menuButton = GameObject.FindGameObjectWithTag("MenuButtonTwo");
      }
       
       //if (AgentControl.menuSwitcher == 2) {
        // menuButton.GameObject.Find("Canvas/DeathScreen/BackToMenu");
      // }
       //menuButton.SetActive(false);
       Assassin = GameObject.Find("Assassin");
      
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void activateMenuButton() {
       menuButton.SetActive(true);
       Cursor.lockState = CursorLockMode.None;
       movement.speed = 0;
       Assassin.SetActive(false);
   
    }
    
    public static void deactivateMenuButton() {
      menuButton.SetActive(false);
    }
    
    public void goToMainMenu() {
      SceneManager.LoadScene("Menu");
      //Debug.Log("works");
      AgentControl.playerMurdered = false;
      movement.speed = 4;
      Assassin.SetActive(true);
      //Cursor.lockState = CursorLockMode.Locked;
     
      
      
      }
}
