using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform endTarget;
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Tacking start position and creating path cube should follow using NavMesh
    public void ReturnToStart()
    {
        agent.enabled = false;
        transform.position = startPosition;
        agent.enabled = true;
        agent.SetDestination(endTarget.position);
    }
}
