using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.AI;

 
public class HidingTime : MonoBehaviour
{
    //public GameObject myHands; //reference to your hands/the position where you want your object to go
    //bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    //bool hasItem; // a bool to see if you have an item in your hand

    //public NavMeshAgent agent;

    public bool canHide;

    //public GameObject flare;

    //[Range(0, 100)] public float speed;
    //public Collider sphereColl;
    // Start is called before the first frame update
    void Start()
    {

        //agent = GetComponent<NavMeshAgent>();
        canHide = false;
        //agent.speed = speed;

        //sphereColl = GetComponent<Collider>();
    }
    
 
    // Update is called once per frame
    void Update()
    {
        if(canHide == true) // if you enter thecollider of the objecct
        {
            //Debug.Log("HIT");


                //sphereColl.enabled = !sphereColl.enabled;
            //if (Input.GetKeyDown("e"))  // can be e or any key
            //{

                //canHide = false;
                //Destroy(flare);

                GameObject.Find("Warrior").GetComponent<enemyAInoLight>().enabled = false;
                GameObject.Find("Warrior").GetComponent<AttackPlayer>().enabled = false;
                GameObject.Find("Warrior").GetComponent<FollowingEnemy>().enabled = false;
                GameObject.Find("Cat_Lite").GetComponent<WanderingEnemyAI>().enabled = false;
                GameObject.Find("Cat_Lite").GetComponent<AttackPlayer>().enabled = false;
                GameObject.Find("Cat_Lite").GetComponent<FollowingEnemy>().enabled = false;

                GameObject.Find("Warrior").GetComponent<AdvancedWanderAI>().enabled = true;
                GameObject.Find("Cat_Lite").GetComponent<CatWanderAI>().enabled = true;

                //speed = 1.5f;


                //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                //ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                //ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets the position of the object to your hand position
                //ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                
            //}
        }
        else
        {
            GameObject.Find("Warrior").GetComponent<enemyAInoLight>().enabled = true;
            GameObject.Find("Cat_Lite").GetComponent<WanderingEnemyAI>().enabled = true;
            //speed = 1.5f;
        }
        //if (Input.GetKeyDown("q") && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
       // {
           // ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
         
           // ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
        //}
    }

    
   private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "HidePlace") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canHide = true;  //set the pick up bool to true
            //ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canHide = false; //when you leave the collider set the canpickup bool to false
     
    }
    
}
