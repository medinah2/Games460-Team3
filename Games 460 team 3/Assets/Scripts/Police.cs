using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    public AudioSource Popo;
    public AudioClip Whistle;
    public Transform assassin;
    public Transform Pol;
    private NavMeshAgent police;
    public static bool hunting = false;
    public static bool whistle = false;
    public static bool caught = false;
    Vector3 destination;
    Vector3 start;


    // Added for character movement
    Animator animator;
    public float velocity = .0f;
    public float acceleration = .4f;
    public float deceleration = .8f;
    int velocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");

        police = this.GetComponent<NavMeshAgent>();

        start = Pol.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!caught)
        {
            if (hunting && Vector3.Distance(destination, assassin.position) > 1.0f)
            {
                destination = assassin.position;
                police.destination = destination;

                velocity += Time.deltaTime * acceleration;

                animator.SetFloat(velocityHash, velocity);

            }
        }

        if(caught)
        {
            police.destination = start;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player" && AgentControl.collectEnough == true && !caught)
        {
            hunting = true;
            destination = assassin.position;
            police.destination = destination;

            if(!whistle)
            {
                Popo.PlayOneShot(Whistle);
                whistle = true;
            }

           
        }
       
    }


}
