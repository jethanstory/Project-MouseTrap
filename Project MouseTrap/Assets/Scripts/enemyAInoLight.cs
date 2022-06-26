//Enemy AI with without light functions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//needed this to reset speed to 1.5 if player escapes the enemy under desk while in pursuit
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class enemyAInoLight : MonoBehaviour
{
   public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;


    //needed this to reset speed to 1.5 if player escapes the enemy under desk while in pursuit
    public NavMeshAgent agent;


    //public GameObject lightSource;
    public Transform fpsTarget;
    Rigidbody theRigidBody;
    Renderer myRenderer;

    public GameObject playa;
    public bool hasCol;

    public bool isOn = false;

    //public bool canHide;

    //private Light enemyLight;
    // Start is called before the first frame update
    void Start()
    {
       myRenderer = GetComponent<Renderer>();
       theRigidBody = GetComponent<Rigidbody>();

       //canHide = false;
       hasCol = true;

       playa = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        checkColli();
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance && hasCol == false) {
            //myRenderer.material.color = Color.yellow;

            GameObject.Find("Warrior").GetComponent<AdvancedWanderAI>().enabled = false;
            GameObject.Find("Warrior").GetComponent<FollowingEnemy>().enabled = true;
            lookAtPlayer();
            if (fpsTargetDistance < attackDistance) {
                //myRenderer.material.color = Color.red;
                GameObject.Find("Warrior").GetComponent<AttackPlayer>().enabled = true;
                //attackPlease();
            }
        }
        
        else{
            //myRenderer.material.color = Color.blue;

            //needed this to reset speed to 1.5 if player escapes the enemy under desk while in pursuit
            agent.speed = 1.5f;
            GameObject.Find("Warrior").GetComponent<AdvancedWanderAI>().enabled = true;
            GameObject.Find("Warrior").GetComponent<FollowingEnemy>().enabled = false;
            GameObject.Find("Warrior").GetComponent<AttackPlayer>().enabled = false;
             gameObject.GetComponent<NavMeshAgent>().enabled = true;
            //enemyLight.color = Color.white;
        }
        
    }

    void lookAtPlayer() {
        Vector3 dir = fpsTarget.position - transform.position;
        dir.y = 0;//This allows the object to only rotate on its y axis
        //dir.z = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);


        //Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        //transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
        
    }

    void attackPlease() {
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
        //enemyLight.color = Color.red;
        //lightSource.SetActive(true);
        
    }

    void checkColli() {
        if (playa.GetComponent<EnteredTrigger>().triggerFlip) {
            hasCol = true;
        }
        else {
            hasCol = false;
        }
    }

    
}

