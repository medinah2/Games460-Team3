using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianAI : MonoBehaviour
{
    private NavMeshAgent Ped;
    public GameObject[] Waypoints;
    public static bool night = false;
    public int random;
    Animator animator;
    public Vector3 velocity;
    Vector3 lastPosition;
    int velocityHash;
    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
        Ped = GetComponent<NavMeshAgent>();
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        random = Random.Range(0, Waypoints.Length);
        Ped.destination = Waypoints[random].transform.position;
    }
    void Update()
    {
        animator.SetFloat(velocityHash, 1f);

        if (Vector2.Distance(Ped.destination, Ped.transform.position) < 2 && !night)
        {

            Selector();
            
        }
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        velocity.y = 0;
        var velocityMagnitude = velocity.magnitude;
        velocity = velocity.normalized;
        var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
        var rightDotProduct = Vector3.Dot(transform.right, velocity);

        if (night)
        {
            

            GameObject[] Sleep;
            Sleep = GameObject.FindGameObjectsWithTag("Night");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject Ni in Sleep)
            {
                Vector3 diff = Ni.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = Ni;
                    distance = curDistance;
                }
            }
            Ped.destination = closest.transform.position;

            if (Vector2.Distance(Ped.destination, Ped.transform.position) < 2)
            {
                Destroy(gameObject);
            }
        }
        // where animator stuff would be
        // animator.SetFloat(velocityHash, Mathf.Abs(velocity.x += Time.deltaTime * movementSpeed));
        animator.SetFloat(velocityHash, 0.6f);

    }
    void Selector()
    {
        Ped.speed = Random.Range(2, 3.5f);
        random = Random.Range(0, Waypoints.Length);
        Ped.destination = Waypoints[random].transform.position;



    }
    // Update is called once per frame

}
