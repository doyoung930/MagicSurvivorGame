using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float enemySpeed = 5f;
    NavMeshAgent navMeshAgent;
    private EnemyHealth health;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = GameObject.FindWithTag("Player").transform;

        //navMeshAgent.speed = enemySpeed;
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        navMeshAgent.SetDestination(target.position);
    }
}
