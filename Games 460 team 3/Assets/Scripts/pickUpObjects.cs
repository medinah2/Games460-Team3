using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObjects : MonoBehaviour
{

    // range var represents how far the player can be from food and be able to pick it up
    public float range = 50;
    // fireRate var represents delay between being about to pick up food
    public float fireRate = .3f;
    
    //public AudioSource audioSource;
    //public AudioClip audioClip;
    
   // public AudioClip audioClip2;
 
   //public AudioClip audioClip3;
    //public AudioClip audioClip4;
    
    /* bool shouldPlaySound determines whether or not the playEatSound method is called based on if it's set to true or false
    */
    
    public static bool shouldPlaySound;
    
    /* bool shouldPlayDrink determines whether or not the playDrinkSound method is called based on if it's set to true or false
    */
    
    //public static bool shouldPlayDrink;
    
    /* bool shouldPlayWineSound determines whether or not the playWineOpening method is called based on if it's set to true or false
    */
    
   // public static bool shouldPlayWineSound;
    
    /* bool shouldPlayStopSound will determine whether or not the playStopSound method will be called based on if it's set to true or false
    */
    
    //public static bool shouldPlayStopSound;
    
    /* bool foodInHand represents whether or not the player is currently holding food. It is set to true & false on the target script.
    */
    
    public static bool foodInHand; 
   
    
    
    bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      // If the user clicks mouse, and the shot cooldown terminates, fireGun method can be called and the user can pick up additional food. 
      
      if (Input.GetMouseButtonDown(0) && canShoot) {
        fireGun();
      }
      
      /* When the DeleteFoodOne method is called on the target script to delete a food object, the static bool variable shouldPlaySound will be set to true if the object being deleted is not a drink. By setting this variable to true, the playEatSound method will be called.
      */
      
      //if (shouldPlaySound == true) {
        //playEatSound();
      //}
      
      /* On the target script, when the DeleteFoodOne method is called to delete a food object, if the food object being deleted is a RedDrink or BlueDrink, the static bool variable shouldPlayDrink is set to true which will then call the playDrinkSound method.  
      */
      
      //if (shouldPlayDrink == true) {
        //playDrinkSound();
      //}
      
      
      //if (shouldPlayWineSound == true) {
       // playWineOpening();
      //}
      
     // if (shouldPlayStopSound == true) {
        //playStopSound();
   //  }
      
    }
      
      
        
    /* The fireGun method uses ray casting so that when the player clicks the mouse, a ray is cast forward  from the position of the camera that is attatched to the player capsule. When this ray collides with or "hits" a target(which in this case is a food game object), the OnHit method will be called on the Target script which will place the food game object on the tray the player is holding. 
    */
    
    void fireGun() {
      Debug.Log("fired!");
      Ray r = new Ray(transform.position + transform.forward, transform.forward);
      RaycastHit hit;
       
      if (Physics.Raycast(r, out hit, range)) {
        Target targetHit = hit.collider.GetComponent<Target>();
         
        if (targetHit != null) {
          targetHit.OnHit();
          Debug.Log("testing");
             
        }  
        
      }
      
      // After a successful hit, the StartCourtine method is called to initiate a cooldown between hits.
      
      StartCoroutine("shotCooldown");
    }
    
    
    /* shotCooldown will initially set canShoot to false meaning the player cannot pick up additional food objects. After waiting for a specified delay which is determined by the value fireRate is set to, canShoot is set to true and the player can pick up food objects again.
    */
    
    IEnumerator shotCooldown() {
      canShoot = false;
      yield return new WaitForSeconds(fireRate);
      canShoot = true;
    }
       
        
    
    private void OnDrawGizmos() {
      Ray r = new Ray(transform.position + transform.forward, transform.forward);
      Gizmos.color = Color.red;
      Gizmos.DrawRay(r);
    }
    
    // When called, this method will play a sound effect of an individual munching on food.
    
    //public void playEatSound() {
    //  audioSource.PlayOneShot(audioClip, 13);
     // shouldPlaySound = false;

    
    // When called, this method will play a sound effect of an individual drinking out of a straw. 
    
   // public void playDrinkSound() {
    //  audioSource.PlayOneShot(audioClip2,10);
    //  shouldPlayDrink = false; 
    
    
    // When called, this method will play a "pop" sound effect of a wine bottle being opened.
    
   // public void playWineOpening() {
   //   audioSource.PlayOneShot(audioClip3, 11);
   //   shouldPlayWineSound = false;
    
    
    // When called, this method will play a "stop" sound effect of a man yelling stop. 
    
   // public void playStopSound() {
    //  audioSource.PlayOneShot(audioClip4, 11);
     // shouldPlayStopSound = false; 
}  
     
   


