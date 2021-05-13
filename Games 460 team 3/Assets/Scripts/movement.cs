using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public Slider SensitivitySlider;
    public Transform playerTransform;
    public CharacterController playerCharacterController;
    float pitch = 0;
    float yaw = 0;
    public static float sensitivity = 2;
    public static float speed = 4;
    public static int enableCameraRotation = 1;

    public GameObject instructionBox;


    //public static GameObject playerCamera;

    public static int evidenceCollected = 0;
    // Start is called before the first frame update

    void Start()
    {

        sensitivity = sensitivityManager.playerSensitivity;

        //sensitivity = GameObject.FindGameObjectWithTag("GameManagement").GetComponent<sensitivityManager>().playerSensitivity;
        SensitivitySlider.value = sensitivity;

       // playerCamera = GameObject.Find("Player/PlayerView");
        //Changes the lock state of our cursor to locked.
        //This hides the cursor and keeps it locked to the center of the game view.
        //The CursorLockToggle method handles unlocking - to unlock or relock the cursor, press ESC.
        //Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("evidenceCollected", 0);


        //This code automatically grabs the references we need to components on the player object.

        //Shows instruction popup
        instructionBox.SetActive(true);
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MovePlayer();
        Debug.Log("sensitivity: " + sensitivity);
    }


    void RotateCamera()
    {
       if (enableCameraRotation == 1) {
        //Add or subtract rotation based on where the mouse is moving
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        //We clamp the pitch so that the player isn't able to rotate their head too far up or down.
        pitch = Mathf.Clamp(pitch, -60f, 60f);

        //camera rotates completely, fix use clamp or if statements
        Vector3 targetPlayerRotation = new Vector3(0, yaw);
        playerTransform.eulerAngles = targetPlayerRotation;

        Vector3 targetCameraRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetCameraRotation;
        }
    }

    void MovePlayer()
    {
       // if (enableCameraRotation == 1) {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 vel = playerTransform.forward * v + playerTransform.right * h + Vector3.down;
        vel = Vector3.ClampMagnitude(vel, 1f);
        playerCharacterController.Move(vel);
        //}
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
      GUI.skin.label.fontSize = 25;
      evidenceCollected = PlayerPrefs.GetInt("evidenceCollected");
      // sets gui text color to black to easily see
      GUI.contentColor = Color.red;

      // if statement to determine if enough evidencr has been collected -- set to 5 but can be updated as we continue development
      //if(evidenceCollected >= 5){
        //GUI.Label(new Rect(Screen.width/16, Screen.height/19, 600,30), "You have gathered enough evidence!");
      //}else{
       // GUI.Label(new Rect(Screen.width/16,Screen.height/19,300,30), "Evidence Collected: " + evidenceCollected + "/5");
     // }
    }


    public void AdjustSensitivity(float newSensitivity) {
      sensitivity = newSensitivity;

    }

    // Gets rid of instruction box when press button
    public void StartButton()
    {
        instructionBox.SetActive(false);
        Time.timeScale = 1f;
        //locks once button is pressed
        Cursor.lockState = CursorLockMode.Locked;
    }

}
