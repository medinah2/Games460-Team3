using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    
    
    // foodie GameObject represents food being picked up
    public GameObject foodie;
    
    // holdingFood GameObject represents the tray where the food is placed on
    public GameObject holdingFood;
    

   
    
    void Start()
    {
        
    }

    
    void Update()
    {
    // Press K to destroy game object in hand
    if (Input.GetKeyDown(KeyCode.K)) {
       
        DeleteFoodOne();
     }
    
    
    }
     
     
    
   
    
    
    public void OnHit() {
      
      /* When the player hits a food game object by clicking on it, an if statement would first be called to check if there is a food object already being held. If foodInHand returns true, the player won't be able to pick up additional food, but if foodInHand returns false, the player will be able to do so. To pick up the food, the food game object that is hit is parented to the tray game object which is named holdingFood in this case. The food game object is then positioned on top of tray. Once the food is successfully picked up, the bool foodInHand is set to true and this indicates that tray is occupied and the user cannot pick up more food until it is deleted. Lastly, when a food game object is currently being held, it is given the tag slotOneFood. This tag identifies that the food is on the tray, and can be deleted when the DeleteFoodOne method is called.  
      */
      
      /* I also used multiple different if statements in this method simply for food-placement. Certain food objects were placed differently on the tray when hit so I needed to adjust their positions individually 
      */
      
      //if (pickUpObjects.foodInHand != true) {
      
        if (foodie.name == "Item") {
          foodie.transform.parent = holdingFood.transform;
          foodie.transform.position = holdingFood.transform.position + transform.forward * -0.06f;
          //foodie.transform.position = holdingFood.transform.position + transform.up * 0.03f + transform.forward * -0.10f;
         // foodie.gameObject.tag = "slotOneFood";
           
         // Destroy(foodie);
        }
    }

    void DeleteFoodOne() {
      Destroy(foodie);
    }
        
    
      
    
   
}
