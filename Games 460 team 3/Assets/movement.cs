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

    void Start()
    {
        //Changes the lock state of our cursor to locked. 
        //This hides the cursor and keeps it locked to the center of the game view.
        //The CursorLockToggle method handles unlocking - to unlock or relock the cursor, press ESC.
        Cursor.lockState = CursorLockMode.Locked;

        //This code automatically grabs the references we need to components on the player object.
        
        
    }

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

    void CursorLockToggler() 
    {
        // If the user presses the escape key, cursor is unlocked and is no longer at the center of the screen & can be moved around. 
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
