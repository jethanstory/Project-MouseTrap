//Player Movement system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 1f; //12
    public float gravity = -0.0981f;
    public float jumpHeight = 0.1f; //3

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool canIClimb;


    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //float y = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        //Vector3 move = transform.right * x + transform.up * y;

        controller.Move(move * speed * Time.deltaTime);


        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //-4
        }

        if (Input.GetKey("left shift") )//&& isGrounded)
        {
            speed = 2f; //20
        }
        else
        {
            speed = 1f; //12
        }
        if (isGrounded && Input.GetButton("c"))
        {
            //float g = Input.GetAxis("Horizontal");
            //float h = Input.GetAxis("Vertical");
            transform.position = new Vector3(x,0.1413f,z);
        }
        velocity.y += gravity * Time.deltaTime;
        //velocity.y += gravity;

        controller.Move(velocity * Time.deltaTime);
    }
 
   
}
//}
