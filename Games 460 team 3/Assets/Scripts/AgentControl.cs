using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



// https://youtu.be/4Kj6YUPLWCw

public class AgentControl : MonoBehaviour {

  public GameObject shirt;
  public GameObject WinScreen;
  public GameObject DeathScreen;
  public GameObject OptionsScreen;
  //public GameObject optionsButton;
    
  
  public Transform player;
  private NavMeshAgent assassin;
  Vector3 destination;
  int evidenceCollected;
    public static bool collectEnough = false;
    public bool moved = false;
    public static bool playerMurdered = false;
    public static int menuSwitcher;
    public static int optionsSwitcher;
    public Transform assassinSpawnPoint1;
    public Transform assassinSpawnPoint2;
    public Transform assassinSpawnPoint3;
    public Transform assassinSpawnPoint4;
    public Transform assassinSpawnPoint5;
    public Transform assassinSpawnPoint6;
    public Transform assassinSpawnPoint7;
    public Transform assassinSpawnPoint8;
    public Transform assassinSpawnPoint9;
    public GameObject sneakyAssassin;

    // Added for character movement
    Animator animator;
    public float velocity = .0f;
    public float acceleration = .4f;
    public float deceleration = .8f;
    int velocityHash;


    Vector3[] assassinSpawnPositions = new Vector3[11];


    // Start is called before the first frame update
    void Start()
    {
        
     
        
       OptionsScreen.SetActive(false);
      //OptionsScreen = GameObject.Find("OptionsMenu");

      animator = GetComponent<Animator>();
      velocityHash = Animator.StringToHash("Velocity");
       // OptionsScreen = GameObject.FindGameObjectWithTag("OptionsBut");

        assassinSpawnPositions[0] = assassinSpawnPoint1.transform.position;
        assassinSpawnPositions[1] = assassinSpawnPoint2.transform.position;
        assassinSpawnPositions[2] = assassinSpawnPoint3.transform.position;
        assassinSpawnPositions[3] = assassinSpawnPoint4.transform.position;
        assassinSpawnPositions[4] = assassinSpawnPoint5.transform.position;
        assassinSpawnPositions[5] = assassinSpawnPoint6.transform.position;
        assassinSpawnPositions[6] = assassinSpawnPoint7.transform.position;
        assassinSpawnPositions[7] = assassinSpawnPoint8.transform.position;
        assassinSpawnPositions[8] = assassinSpawnPoint9.transform.position;

        assassin = this.GetComponent<NavMeshAgent>();
        destination = assassin.destination;
        collectEnough = false;
        playerMurdered = false;

    }

    // Update is called once per frame
    void Update()
    {
        
     if (Input.GetKey(KeyCode.O)) {
        movement.enableCameraRotation = 0;
        WinScreen.SetActive(false);
        DeathScreen.SetActive(false);
        //optionsSwitcher = 1;
        OptionsScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        //backToMenuButton.activateOptions();
        
     
       //optionsButton.SetActive(true);
         
         
      }
      if (Input.GetKey(KeyCode.X)) {
         movement.enableCameraRotation = 1;
         OptionsScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
       
         //optionsButton.SetActive(false);
       
      }

        evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");


      if (Vector3.Distance(destination, player.position) > 1.0f && !SafeZone.destroy){
        destination = player.position;
        assassin.destination = destination;

        velocity += Time.deltaTime * acceleration;

        animator.SetFloat(velocityHash, velocity);
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

                velocity += Time.deltaTime * acceleration;

                animator.SetFloat(velocityHash, velocity);

            }

        if (SafeZone.natural && !SafeZone.destroy)
        {
            GameObject[] Peds;
            Peds = GameObject.FindGameObjectsWithTag("Pedestrian");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject Ped in Peds)
            {
                Vector3 diff = Ped.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = Ped;
                    distance = curDistance;
                }
            }
            destination = closest.transform.position;
            assassin.destination = destination;

            velocity += Time.deltaTime * acceleration;

            animator.SetFloat(velocityHash, velocity);

        }

        if(Vector3.Distance(assassin.transform.position, player.position) < 5 && !Police.caught)
        {
            Music.close = true;
        }
        else {
            Music.close = false;
        }


        if (evidenceCollected == 2 && !PedestrianAI.night && !Police.caught)
        {
            assassin.speed = 2.7f;
        }

        if (evidenceCollected == 4 && !PedestrianAI.night && !Police.caught)
        {
            assassin.speed = 3f;
        }

        if(PedestrianAI.night && !Police.caught)
        {
            SafeZone.natural = false;
            assassin.speed = 4f;
        }

        if(Police.caught)
        {
            assassin.speed = 0f;
        }


        enoughEvidence();

      CheckDestinationReached();

    }

    // If enough evidence has been found, the assassin turns red
    void enoughEvidence(){
      if(evidenceCollected == 5){
        // GetComponentsInChildren<Shirt>().material.color = Color.red;
        shirt.GetComponent<Renderer>().material.color = Color.red;
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
            menuSwitcher = 1;
            WinScreen.gameObject.SetActive(true);
            
            backToMenuButton.activateMenuButton();
            //Destroy(this.gameObject);


            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMurdered = true;
            //movement.speed = 0;
            menuSwitcher = 2;
            DeathScreen.gameObject.SetActive(true);
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


     public void SpawnAssassin() {
         int randomNum = Random.Range(0,9);


         sneakyAssassin.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(assassinSpawnPositions[randomNum]);
    }

}
