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
   // public static GameObject options;


    public static void activateMenuButton() {
      if (AgentControl.menuSwitcher == 1) {
      menuButton = GameObject.FindGameObjectWithTag("MenuButtonOne");

      }
      if (AgentControl.menuSwitcher == 2) {
      menuButton = GameObject.FindGameObjectWithTag("MenuButtonTwo");
      }
      
      Assassin = GameObject.Find("Assassin");
      
       Debug.Log(menuButton);

       menuButton.SetActive(true);
       Cursor.lockState = CursorLockMode.None;
       movement.speed = 0;
       Assassin.SetActive(false);

    }

   // public static void deactivateMenuButton() {
    //  menuButton.SetActive(false);
  //  }

    public static void goToMainMenu() {
      SceneManager.LoadScene("Menu");
      ProgressBar.newProgress = 0;
      AgentControl.playerMurdered = false;
      movement.speed = 4;
      //Assassin.SetActive(true);
      //options.SetActive(false);
      //Cursor.lockState = CursorLockMode.Locked;



      }
}
