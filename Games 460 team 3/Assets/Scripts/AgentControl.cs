using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// https://youtu.be/4Kj6YUPLWCw

public class AgentControl : MonoBehaviour {

  public Transform player;
  private NavMeshAgent assassin;
  Vector3 destination;
  int evidenceCollected;

    // Start is called before the first frame update
    void Start()
    {
        assassin = this.GetComponent<NavMeshAgent>();
        destination = assassin.destination;
        // assassin.setDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {

      evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");


      if (Vector3.Distance(destination, player.position) > 1.0f){
        destination = player.position;
        assassin.destination = destination;
      }

      enoughEvidence();

      CheckDestinationReached();

    }

    // If enough evidence has been found, the assassin turns red
    void enoughEvidence(){
      if(evidenceCollected == 5){
        GetComponent<Renderer>().material.color = Color.red;
        // would also increase speed here 
      }
    }
    void CheckDestinationReached() {
    // Check if we've reached the destination
      // if (!assassin.pathPending)
      // {
      //     if (assassin.remainingDistance <= assassin.stoppingDistance)
      //     {
      //         if (!assassin.hasPath || assassin.velocity.sqrMagnitude == 0f)
      //         {
      //             // Done
      //             print("Destination reached" + assassin.remainingDistance);
      //         }
      //     }
      // }
    }

    private void OnGUI(){
      // // sets gui text color to black to easily see
     GUI.contentColor = Color.black;
      //
      // // if statement to determine if enough evidencr has been collected -- set to 10 but can be updated as we continue development
     //  if (Vector3.Distance(destination, player.position) <= 0.0005f){
      // GUI.Label(new Rect(100,100,300,30), "The Assassin caught you!" + Vector3.Distance(destination, player.position));
      // SceneManager.LoadScene("Start");
      }
    //}

}
