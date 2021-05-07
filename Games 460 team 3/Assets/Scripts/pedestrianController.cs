using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// created using https://youtu.be/MXCZ-n5VyJc

public class pedestrianController : MonoBehaviour
{

  public Vector3 destination;
   Vector3 lastPosition;
   public bool reachedDestination;
    public float stopDistance = 1;
   public float rotationSpeed;
   public float minSpeed = 1f;
   public float maxSpeed = 3.5f;
   public float movementSpeed;
   public Vector3 velocity;
   int velocityHash;

   // public Transform player;
   // Transform head;
   //
   // private Quaternion OriginalRotation;
   // private Quaternion TargetRotation;
   // public float TimeValue = 0.5f;

   public Vector3 Offset;

   Animator animator;

   private void Start()
   {
     animator = GetComponent<Animator>();
     velocityHash = Animator.StringToHash("Velocity");
     // head = animator.GetBoneTransform(HumanBodyBones.Head);
     //
     // OriginalRotation = head.rotation;
     // head.LookAt(player.position);
     // TargetRotation = head.rotation;


       movementSpeed = Random.Range(minSpeed, maxSpeed);
        PedestrianAI.night = false;
   }
   private void Update()
   {
     animator.SetFloat(velocityHash, 1f);

            if (transform.position != destination)
            {
                Vector3 destinationDirection = destination - transform.position;
                destinationDirection.y = 0;

                float destinationDistance = destinationDirection.magnitude;

                if (destinationDistance >= stopDistance)
                {
                    reachedDestination = false;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = true;
                }

                velocity = (transform.position - lastPosition) / Time.deltaTime;
                velocity.y = 0;
                var velocityMagnitude = velocity.magnitude;
                velocity = velocity.normalized;
                var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
                var rightDotProduct = Vector3.Dot(transform.right, velocity);

                // where animator stuff would be
                // animator.SetFloat(velocityHash, Mathf.Abs(velocity.x += Time.deltaTime * movementSpeed));
                animator.SetFloat(velocityHash, 0.6f);


                // head.LookAt(player.position);
                // TargetRotation = head.rotation;
                // head.rotation = Quaternion.Lerp( OriginalRotation , TargetRotation , TimeValue );
                // head.rotation = head.rotation * Quaternion.Euler(Offset);

                // turnInput = Input.GetAxis("Mouse Y");
                // if (Math.Abs(turnInput ) > inputDelay)
                // {
                //     targetRotation *= Quaternion.AngleAxis(rotateVel * -turnInput * Time.deltaTime, Vector3.right);
                //     Vector3 eulerAngles =  targetRotation.eulerAngles;
                //     if (eulerAngles.y < 180)
                //          eulerAngles.y=Mathf.Clamp(eulerAngles.y,0,maxDownAngle);
                //     else
                //          eulerAngles.y = Mathf.Clamp(eulerAngles.y,actualUpangle,360);
                //     targetRotation = Quaternion.Euler(eulerAngles);
                // }
                // transform.rotation = targetRotation;


            }

        if(PedestrianAI.night)
        {
            stopDistance = 1;

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
                destination = closest.transform.position;

            if (reachedDestination)
            {
                Destroy(gameObject);
            }
        }
   }

   // void OnAnimatorIK(){
   //   // if(npcStatePattern.persueTarget != null){
   //     head.SetLookAtWeight(1, 0, 0.5f, 0.5f, 0.7f);
   //     head.SetLookAtPosition(player.position);
   //   // }else{
   //   //   animator.SetLookAtWeight(0);
   //   // }
   // }

   public void SetDestination(Vector3 destination)
   {
       this.destination = destination;
       reachedDestination = false;
   }
}
