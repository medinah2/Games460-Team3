using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisionDetection : MonoBehaviour
{
    public Vector3 homePosition;
    public Transform playerTransform; 

    void Start()
    {
        homePosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/* 
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("goes in");
        if (collision.gameObject.tag == "Assassin") {
            Debug.Log("works");
            playerTransform.transform.position = homePosition;
        }
    }

    */
}
