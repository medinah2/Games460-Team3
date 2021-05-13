using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePlayerRotation : MonoBehaviour
{
    Rigidbody playerBody;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.enableCameraRotation == 0) {
           playerBody.constraints = RigidbodyConstraints.FreezeRotation;
        
        }
    }
}
