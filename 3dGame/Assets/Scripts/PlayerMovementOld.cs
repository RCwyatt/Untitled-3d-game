using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 this script serves the purpose of taking movement
 input from the player and controlling the
 player character's movement 
     */

public class PlayerMovements : MonoBehaviour
{
    
    public CharacterController controller;  //The character controller

    public Transform groundCheck;           //point to check for if the player is touching the ground
    public LayerMask groundMask;            //the ground to check
    public float groundCheckSize = 0.2f;    //the distance from the groundcheck to check for ground

    public float moveSpeed = 10f;           //player's move speed
    public float jumpHeight = 1.5f;         //height of the player's jumps
    public float gravity = -50f;            //speed of gravity
    public float friction = 12f;            //the speed lost when touching the ground
    public float airSpeed = 4f;             //the amount the player can change their speed in the air

    public Text score;                      //the GUI element for the score
    public int points = 0;                  //holds the player's score

    Vector3 velocity;                       //vector for calculating gravity
    public Vector3 direction;               //vector for caluclating xz movement
    bool grounded;                          //bool for checking if the player is grounded

    

    // Update is called once per frame
    void Update()
    {
        score.text = points.ToString();     //update the score gui with the current score
    
        //check if the player is grounded and update the grounded bool
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckSize, groundMask);

        //set the gravity velocity to a constant if on the ground
        if(grounded && velocity.y < 0)
        {
            //it's set to a constant so that the player properly sticks to the ground
            //instead of floating adjacent to it
            velocity.y = -2f;
        }

        //get and store the horizontal and vertical player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //if grounded apply friction to the slow player's movement
        if (grounded)
        {
            direction = direction / friction;
        }

        
        if (grounded)
        {
            //if grounded update the directional vector to the player's input
            //this has the effect of the player keeping momenetum when jumping
            direction += transform.right * x * moveSpeed + transform.forward * z * moveSpeed;
        } else
        {
            //if airborn create a new vector to apply additional air movement at the airspeed
            //this gives the player some limited air control
            Vector3 airMove = transform.right * x * airSpeed + transform.forward * z * airSpeed;
            controller.Move(airMove * Time.deltaTime);
        }
   
        //apply the directional movment to the player
        controller.Move(direction * Time.deltaTime);
       


        //allow jump if grounded
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }

        //calculate gravity
        velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime);

       


    }

    //apply am external force to the player's movement
    public void PushPlayer(Vector3 push)
    {
        direction += push;
        
    }

    
}
