using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 3;

    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    private ZombieStats stats = null;
    private Animator anim = null;

    private void Start()
    {
        stats = GetComponent<ZombieStats>();

        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
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
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);

            //Attack
            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }

            if (Time.time > timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }

        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }

    private void RotateToTarget()
    {
        //transform.LookAt(playerTarget);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        //Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, transform.position.y, playerTarget.transform.position.z);
        //transform.LookAt(targetPosition);
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
    } 
        

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<ZombieStats>();

        if (stats == null)
        {
            Debug.LogError("ZombieStats coponent not found on the same GameObject)");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collision is with the cube
        //if (collision.gameObject.CompareTag("Cube"))
        //{
        //    ArrowStats cubeStats = collision.gameObject.GetComponent<ArrowStats>();
        //    if (cubeStats != null)
        //    {
        //        // Deal damage to the zombie based on cubeStats.damage
        //        stats.TakeDamage(cubeStats.damage);
        //    }
        //}

        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Hit the cube...");
            stats.TakeDamage(10);
        }
    }
}
