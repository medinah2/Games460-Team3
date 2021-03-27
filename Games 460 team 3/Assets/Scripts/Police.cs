using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    public AudioSource Popo;
    public AudioClip Whistle;
    public Transform assassin;
    private NavMeshAgent police;
    public static bool hunting = false;
    public static bool whistle = false;
    Vector3 destination;
<<<<<<< HEAD

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

=======
    // Start is called before the first frame update
    void Start()
    {
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
        police = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hunting && Vector3.Distance(destination, assassin.position) > 1.0f)
        {
            destination = assassin.position;
            police.destination = destination;
<<<<<<< HEAD
            velocity += Time.deltaTime * acceleration;

            animator.SetFloat(velocityHash, velocity);
=======
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player" && AgentControl.collectEnough == true)
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
<<<<<<< HEAD

=======
    
>>>>>>> deeb55abcfbd1c22f2e1d0870b0c9cc81dbff300

}
