using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackController : MonoBehaviour
{
    [SerializeField] private bool isStraight;
    private int correctRotation;
    private int currentRotation;
    private GameObject cube;

    void Start()
    {
        RotateTrack(Random.Range(1, 4));
    }

    // Function responsible for track rotation, called either from Start event, or from InputController on click;
    // If, at the time of rotation, cube is near track, function restores cube speed
    public void RotateTrack(int addRotation = 1)
    {
        transform.RotateAround(transform.position, Vector3.up, addRotation * 90f);
        int modulus = isStraight ? 2 : 4;
        currentRotation = (currentRotation + addRotation) % modulus;
        if (cube != null && currentRotation == correctRotation) cube.GetComponent<NavMeshAgent>().speed = 5f;
    }

    //Checking for colliding object layer & track rotation; in case tracks aren't in correct rotation, object is stopped
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6) return;
        cube = other.gameObject;
        if (currentRotation != correctRotation) cube.GetComponent<NavMeshAgent>().speed = 0f; 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6) cube = null;
    }
}
