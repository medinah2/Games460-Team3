using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform playerTransform;
    public CharacterController playerCharacterController;
    float pitch = 0;
    float yaw = 0;
    public float sensitivity;
    public float speed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MovePlayer();
    }

    void RotateCamera()
    {
        //Add or subtract rotation based on where the mouse is moving
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        //camera rotates completely, fix use clamp or if statements
        Vector3 targetPlayerRotation = new Vector3(0, yaw);
        playerTransform.eulerAngles = targetPlayerRotation;

        Vector3 targetCameraRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetCameraRotation;
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 vel = playerTransform.forward * v + playerTransform.right * h + Vector3.down;
        playerCharacterController.Move(vel);
    }
}
