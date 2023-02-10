//NavMesh based AI wander system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class AdvancedWanderAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshAgent fpsTarget;
    // Start is called before the first frame update

    Animator animator;

    //[Range(0, 500)] public float speed; //100
    [Range(1, 500)] public float walkRadius;
    //[Range(0, 500)] public float acceleration; //100
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            //agent.speed = speed;
            agent.speed = 1.5f;
            //agent.acceleration = acceleration;
            agent.SetDestination(RandomNavMeshLocation());


            animator = GetComponent<Animator>();

            animator.SetBool("isWalking", true);
        }
    }

    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("isWalking", true);
        agent.speed = 1.5f;
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
            //acceleration = 0f;
        }
        
        //agent.SetDestination(fpsTarget)

    }
}
