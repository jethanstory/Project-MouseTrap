using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class AttackPlayer : MonoBehaviour
{
    public float damping;

    public NavMeshAgent agent;
    public NavMeshAgent fpsTarget;
    public Transform player;

    Animator animator;


    // Start is called before the first frame update

    [Range(0, 500)] public float speed; //100
    [Range(1, 500)] public float walkRadius;
    [Range(0, 500)] public float acceleration; //100
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = speed;
            agent.acceleration = acceleration;
            agent.SetDestination(player.position);

            animator = GetComponent<Animator>();

            animator.SetBool("isRunning", true);
        }
    }

    /*public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    } */



    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);


        //Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
        //float distance = Vector3.Distance(player.transform.position,transform.position);
        //if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        //{
            
            //agent.SetDestination(RandomNavMeshLocation());
        //}

        //transform.LookAt(player);
        agent.SetDestination(player.position);
        

    }
}
