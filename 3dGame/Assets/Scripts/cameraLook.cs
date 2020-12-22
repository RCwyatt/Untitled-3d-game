using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script serves the purpose of controlling
 the player's mouse movment input and changing
 the camera to suit it
     
     */

public class CameraLook : MonoBehaviour
{
   
    public float mouseSensitivity = 100f; //camera movment speed

    public Transform playerBody; //object for the player

    float yRotation = 0f; 
    

    // Start is called before the first frame update
    void Start()
    {
        //prevent the cursor from moving on the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get the player's mouse input and apply sensitivity and time
        float xAxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= yAxis; 
        yRotation = Mathf.Clamp(yRotation, -90f, 90f); //limit the y axis to not go beyond straight up and down

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f); //apply y rotation
        playerBody.Rotate(Vector3.up * xAxis); //apply x rotation
    }
}
