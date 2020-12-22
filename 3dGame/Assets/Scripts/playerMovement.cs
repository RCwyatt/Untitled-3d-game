using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;

    public Transform groundCheck;
    public float groundCheckSize = 0.2f;
    public LayerMask groundMask;


    public float moveSpeed = 10f;
    public float jumpHeight = 1.5f;
    public float gravity = -50f;
    public float friction = 12f;
    public float airSpeed = 4f;

    public Text score;

    public int points = 0;

    public GameObject startPoint;


    Vector3 velocity;
    public Vector3 direction;
    bool grounded;

    

    // Update is called once per frame
    void Update()
    {
        score.text = points.ToString();
    

        grounded = Physics.CheckSphere(groundCheck.position, groundCheckSize, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }


        float x = 0;
        float z = 0;

  

        if (grounded)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

        }
       
        

        if (grounded)
        {
            direction = direction / friction;
        }
      

        //movement vector
        direction += transform.right * x * moveSpeed + transform.forward * z * moveSpeed;



        controller.Move(direction * Time.deltaTime);
        

        if (!grounded)
        {
            float tx = Input.GetAxis("Horizontal");
            float tz = Input.GetAxis("Vertical");

            Vector3 airMove = transform.right * tx * airSpeed + transform.forward * tz * airSpeed;
            controller.Move(airMove * Time.deltaTime);
        }



        //allow jump if grounded
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }

        //calculate gravity
        velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime);

       


    }

    public void PushPlayer(Vector3 push)
    {
        direction += push;
        
    }

    
}
