using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_Movement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform camTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        camTransform = Camera.main.transform;
    }

    public void Move(Vector2 direction)
    {
        agent.destination = transform.position + (direction.y *Vector3.forward) + (direction.x * Vector3.right); /*transform.forward.normalized) + (direction.x * transform.right.normalized);*/
    }                   
}
