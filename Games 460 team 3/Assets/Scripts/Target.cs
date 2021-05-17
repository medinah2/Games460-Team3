using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public AudioClip Rip;
    public AudioClip Pickup;
    

    // foodie GameObject represents food being picked up
    public GameObject foodie;

    // holdingFood GameObject represents the tray where the food is placed on
    public GameObject holdingFood;

    int evidenceCollected;

    int duration;

    int tempCount;




    void Start()
    {
      
      //sets items to a random color -- not necessary, just added so that we could differentiate evidence objects
      GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

      duration = Random.Range(0, 60);
      // Debug.Log(duration);
    }


    void Update()
    {
      // gets current value of evidenceCollected
      evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");
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

        if (foodie.gameObject.tag == "Evidence") {
         //  foodie.transform.parent = holdingFood.transform;
         //  foodie.transform.position = holdingFood.transform.position + transform.forward * -0.06f;
         //  //foodie.transform.position = holdingFood.transform.position + transform.up * 0.03f + transform.forward * -0.10f;
         // // foodie.gameObject.tag = "slotOneFood";
         // evidenceCollected++;
         // Debug.Log("evidenceCollected:  " + evidenceCollected);
         //
         //
         // PlayerPrefs.SetInt("evidenceCollected", evidenceCollected);
         // Destroy(foodie);
         evidenceCollected++;
         Debug.Log("evidenceCollected:  " + evidenceCollected);

         AudioSource.PlayClipAtPoint(Pickup, this.transform.position, .1f);

         PlayerPrefs.SetInt("evidenceCollected", evidenceCollected);

         Destroy(gameObject);

         Debug.Log("clicked");

         ProgressBar.newProgress += 1.0f;

         ProgressBar.incProgressValue(ProgressBar.newProgress);

        }
    }

    private void OnTriggerEnter(Collider other){

      evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");

      if(other.name == "Player"){
        // foodie.transform.parent = holdingFood.transform;
        // foodie.transform.position = holdingFood.transform.position + transform.forward * -0.06f;
        //
        // evidenceCollected++;
        // Debug.Log("evidenceCollected:  " + evidenceCollected);
        //
        // AudioSource.PlayClipAtPoint(Pickup, this.transform.position, .1f);
        //
        //     PlayerPrefs.SetInt("evidenceCollected", evidenceCollected);
        //
        // Destroy(gameObject);
        Debug.Log("evidence collided");
      }

      if(other.name == "Assassin" && SafeZone.destroy)
        {
            SafeZone.destroy = false;
            AudioSource.PlayClipAtPoint(Rip, this.transform.position);
            Destroy(gameObject);
        }
    }

    void DeleteFoodOne() {
      // Kills the game object after a random range of seconds after loading the object
      Destroy(foodie, duration);
    }




}
