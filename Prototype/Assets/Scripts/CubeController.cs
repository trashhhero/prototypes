using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform endTarget;
    private Vector3 startPosition;
    
    // Creating path cube should follow using NavMesh
    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(endTarget.position);
    }

    public void ReturnToStart()
    {
        agent.enabled = false;
        transform.position = startPosition;
        agent.enabled = true;
        agent.SetDestination(endTarget.position);
    }
}
