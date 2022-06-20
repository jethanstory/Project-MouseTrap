using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 //[RequireComponent(typeof(Rigidbody))]
 //[RequireComponent(typeof(CapsuleCollider))]
public class WallClimb : MonoBehaviour
{
    bool canIClimb;
    GameObject ObjectIwantToClimb;
    Ray ray; public float range = 1f; public float climbspeed = 5f; public float sticktowallforce = 5f;
    public float gravity = -9.81f;
 // Start is called before the first frame update

    public CharacterController controller;

    public float speed = 1f;

/*
    public float WalkSpeed = 5f;
     public float ClimbSpeed = 3f;
     public LayerMask wallMask;
 
     bool climbing;
 
     Vector3 wallPoint;
     Vector3 wallNormal;
 
     Rigidbody body;
     CapsuleCollider coll;
 
*/

 void Start()
 {
    canIClimb = false;
 }
 // Update is called once per frame
 void Update()
 {
    float y = Input.GetAxis("Vertical");


    if(canIClimb == true) // if you enter thecollider of the objecct
        {
            
            if (Input.GetKey(KeyCode.Space))
             {
                GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
                Vector3 move = transform.up * y; 
                // transform.position += transform.forward * Time.deltaTime * sticktowallforce;
                // transform.position += transform.up * Time.deltaTime * climbspeed;
                controller.Move(move * speed * Time.deltaTime);
             }

             

        }
    /*
     RaycastHit hit;
     if (Physics.Raycast(transform.position, transform.forward, out hit, range))
     {
         if (hit.transform.tag == "Wall")
         {
             if (Input.GetKey(KeyCode.Space))
             {
                 transform.position += transform.forward * Time.deltaTime * sticktowallforce;
                 transform.position += transform.up * Time.deltaTime * climbspeed;
                
             }
         }
     } else
     {
         gravity = -7.81f;
     }
     */ 
 }
  
 

 private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Wall") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            Debug.Log("HIT");
            canIClimb = true;  //set the pick up bool to true
            ObjectIwantToClimb = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canIClimb = false; //when you leave the collider set the canpickup bool to false
        GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = true;
    }
 
   
}


/*
// Use this for initialization
     void Start ()
     {
         body = GetComponent<Rigidbody>();
         coll = GetComponent<CapsuleCollider>();
     }
     
     void FixedUpdate ()
     {
         if (NearWall())
         {
             if (FacingWall())
             {
                 // if player presses the climb button
                 if (Input.GetKeyUp(KeyCode.C))
                 {
                     climbing = !climbing;
                 }
             }
             else
             {
                 climbing = false;
             }
         }
         else
         {
             climbing = false;
         }
 
         if (climbing)
         {
             ClimbWall();
         }
         else
         {
             Walk();
         }
     }
 
     void Walk()
     {
         body.useGravity = true;
 
         var v = Input.GetAxis("Vertical");
         var h = Input.GetAxis("Horizontal");
         var move = transform.forward * v + transform.right * h;
 
         ApplyMove(move, WalkSpeed);
     }
 
     bool NearWall()
     {
         return Physics.CheckSphere(transform.position, 3f, wallMask);
     }
 
     bool FacingWall()
     {
         RaycastHit hit;
         var facingWall = Physics.Raycast(transform.position, transform.forward, out hit, coll.radius + 1f, wallMask);
         wallPoint = hit.point;
         wallNormal = hit.normal;
         return facingWall;
     }
 
     void ClimbWall()
     {
         body.useGravity = false;
 
         GrabWall();
 
         var v = Input.GetAxis("Vertical");
         var h = Input.GetAxis("Horizontal");
         var move = transform.up * v + transform.right * h;
 
         ApplyMove(move, ClimbSpeed);
     }
 
     void GrabWall()
     {
         var newPosition = wallPoint + wallNormal * (coll.radius - 0.1f);
         transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
 
         if (wallNormal == Vector3.zero)
             return;
 
         transform.rotation = Quaternion.LookRotation(-wallNormal);
     }
 
     void ApplyMove(Vector3 move, float speed)
     {
         body.MovePosition(transform.position + move * speed * Time.deltaTime);
     }
 }
 */
 
