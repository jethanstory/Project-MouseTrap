using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    bool canIClimb;
    GameObject ObjectIwantToClimb;
    Ray ray; public float range = 1f; public float climbspeed = 5f; public float sticktowallforce = 5f;
    public float gravity = -9.81f;
 // Start is called before the first frame update
 void Start()
 {
    
 }
 // Update is called once per frame
 void Update()
 {
    float y = Input.GetAxis("Vertical");


    if(canIClimb == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKey(KeyCode.Space))
             {
                Vector3 move = transform.up * y; 
                // transform.position += transform.forward * Time.deltaTime * sticktowallforce;
                // transform.position += transform.up * Time.deltaTime * climbspeed;
                
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
     
 }
 */
 }

 private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Wall") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canIClimb = true;  //set the pick up bool to true
            ObjectIwantToClimb = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canIClimb = false; //when you leave the collider set the canpickup bool to false
     
    }
 
   
}
