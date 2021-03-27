using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathMessage : MonoBehaviour
{
    Text deathMSG;
    // Start is called before the first frame update
    void Start()
    {
      deathMSG = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
       if (AgentControl.playerMurdered == true) {
          deathMSG.text = "You Died!";
       }
       else {
          deathMSG.text = "";
       }
    }
}
