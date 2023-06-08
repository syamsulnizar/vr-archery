using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    public Transform playerTarget;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }

        else
        {
            Debug.Log("Could not find Player");
        }

        GetReferences();
    }

    private void Update()
    {
        MoveToPlayer();
    }
    private void MoveToPlayer()
    {
        agent.SetDestination(playerTarget.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(playerTarget.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            //Attack
        }
    }

    private void RotateToTarget()
    {
        //transform.LookAt(playerTarget);

        Vector3 direction = playerTarget.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget()
    {

    } 
        

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();

    }
}
