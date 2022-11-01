using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform endTarget;
    
    // Creating path cube should follow
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(endTarget.position);
    }
}
