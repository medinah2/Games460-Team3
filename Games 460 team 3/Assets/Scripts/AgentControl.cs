using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



// https://youtu.be/4Kj6YUPLWCw

public class AgentControl : MonoBehaviour {

  public Transform player;
  private NavMeshAgent assassin;
  Vector3 destination;
  int evidenceCollected;
    public static bool collectEnough = false;
    public bool moved = false;
    public static bool playerMurdered = false;



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


      if (Vector3.Distance(destination, player.position) > 1.0f && !SafeZone.destroy){
        destination = player.position;
        assassin.destination = destination;
      }

            if (SafeZone.destroy)
            {
                GameObject[] Evidence;
                Evidence = GameObject.FindGameObjectsWithTag("Evidence");
                GameObject closest = null;
                float distance = Mathf.Infinity;
                Vector3 position = transform.position;
                foreach (GameObject Evi in Evidence)
                {
                    Vector3 diff = Evi.transform.position - position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closest = Evi;
                        distance = curDistance;
                    }
                }
                destination = closest.transform.position;
                assassin.destination = destination;


            }





      enoughEvidence();

      CheckDestinationReached();

    }

    // If enough evidence has been found, the assassin turns red
    void enoughEvidence(){
      if(evidenceCollected == 5){
        GetComponent<Renderer>().material.color = Color.red;
            collectEnough = true;
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


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.name == "Police" && Police.hunting)
            {
            Police.caught = true;
            Debug.Log("The Assassin has been captured");
            Destroy(this.gameObject);
            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMurdered = true;
            //movement.speed = 0;

            backToMenuButton.activateMenuButton();
            //something.setactive
            //GameObject.Find(BackToMenu);
            //BackToMenu.SetActive(true);
            //SceneManager.LoadScene("Menu");

        }
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
