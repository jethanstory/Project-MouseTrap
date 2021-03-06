using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{

    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand

    public float foodItems;
    public Text foodScore;

    //public Text notEnough;

    public float secondsCount;

    public GameObject text;

    public GameObject errorText;


    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        secondsCount = 0;
        errorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        secondsCount += Time.deltaTime;

        if (secondsCount > 5) 
        {
            text.SetActive(false);
        }
        //if(canpickup == true) // if you enter thecollider of the objecct
        //{
            //Debug.Log("HIT");


                //sphereColl.enabled = !sphereColl.enabled;
            //if (Input.GetKeyDown("e"))  // can be e or any key
            //{
                //Destroy(radio);

                //GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;

                //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                //ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                //ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets the position of the object to your hand position
                //ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                
            //}
        //}
        //if (Input.GetKeyDown("q") && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
       // {
           // ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
         
           // ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
        //}
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "PickUp") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            foodItems += 1;
            foodScore.text = "Food Count: " + foodItems.ToString();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "EndGame" && foodItems >= 20)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
        else if(other.gameObject.tag == "EndGame" && foodItems <= 20)
        {
            //notEnough.text = "";
            errorText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        errorText.SetActive(false);
        canpickup = false; //when you leave the collider set the canpickup bool to false
     
    }
}
