using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public Transform playerTransform;
    public CharacterController playerCharacterController;
    float pitch = 0;
    float yaw = 0;
    public static float sensitivity = 5;
    public float speed;
    
    //public static GameObject playerCamera;

    public int evidenceCollected = 0;
    // Start is called before the first frame update

    void Start()
    {
    
       // playerCamera = GameObject.Find("Player/PlayerView");
        //Changes the lock state of our cursor to locked.
        //This hides the cursor and keeps it locked to the center of the game view.
        //The CursorLockToggle method handles unlocking - to unlock or relock the cursor, press ESC.
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("evidenceCollected", 0);

        
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

    // created this function to display the amount of evidenceCollected --> this can later be edited to display in a health bar type format,
    // but for now this is a basic display for our initial prototype (3/4/21)
    private void OnGUI(){
      //gets evidenceCollected value using playerprefs
      evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");
      // sets gui text color to black to easily see
      GUI.contentColor = Color.black;

      // if statement to determine if enough evidencr has been collected -- set to 5 but can be updated as we continue development
      if(evidenceCollected == 5){
        GUI.Label(new Rect(10,10,300,30), "You have gathered enough evidence!");
      }else{
        GUI.Label(new Rect(10,10,300,20), "Evidence Collected: " + evidenceCollected);
      }
    }
    
    
    //public static void AdjustSensitivity(float newSensitivity) {
     // sensitivity = newSensitivity;
    
    //}



}
