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
    // Start is called before the first frame update
    void Start()
    {
        police = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hunting && Vector3.Distance(destination, assassin.position) > 1.0f)
        {
            destination = assassin.position;
            police.destination = destination;
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
    

}
