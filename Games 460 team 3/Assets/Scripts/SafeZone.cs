using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public bool inside;
    public bool increase;
    public bool decrease;
    public static bool destroy;
    public static bool natural = false;
    public float seconds = 15;

    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        //Checks if the player is outside the safe zone and increases the timer
        if (!inside && increase && seconds < 15)
        {
            increase = false;
            StartCoroutine(ReverseTime());
            
        }
        //If seconds ever hit zero the assassin will destroy a piece of evidence
        if(seconds == 0 && !destroy)
        {
            destroy = true;
            seconds = 15;
        }

        if(PedestrianAI.night)
        {
            natural = false;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Changes all the bools on enter to decrease the time
        //Also stops all coroutines so it doesn't double count
        StopAllCoroutines();
        decrease = true;
        increase = false;
        inside = true;
        natural = true;

        
    }
    private void OnTriggerStay(Collider other)
    {
        
        //While inside the safe zones the timer will decrease
            StopCoroutine(ReverseTime());

            if (inside && decrease && seconds > 0)
            {
                natural = true;
                decrease = false;
                StartCoroutine(Time());
                
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        //Allows the timer to increase when the player leaves the safe zone
        //Again stop all coroutines to stop double count
            increase = true;
            decrease = false;
            inside = false;
            natural = false;
            StopCoroutine(Time());
            StopAllCoroutines();

        
    }

    

    IEnumerator Time()
    {
        decrease = false;
        yield return new WaitForSeconds(1);
        decrease = true;
        seconds -= 1;
        

    }

    IEnumerator ReverseTime()
    {
        increase = false;
        yield return new WaitForSeconds(1);
        increase = true;
        seconds += 1;
        
    }
}
