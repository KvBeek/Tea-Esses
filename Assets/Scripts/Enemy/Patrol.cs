using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 originalPosition = Vector3.zero;
    GameObject target = null;

    Vector3 eyesightLocationOriginal = Vector3.zero;
    float eyesightSizeOriginal = 0f;
    SphereCollider sphereCollider = null;

    Vector3 eyesightLocationTargeted = Vector3.zero;
    float eyesightSizeTargeted = 10f;


    bool isFollowing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;

        sphereCollider = GetComponent<SphereCollider>();
        eyesightLocationOriginal = sphereCollider.center;
        eyesightSizeOriginal = sphereCollider.radius;

        eyesightLocationTargeted = Vector3.zero;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.GetComponent<Player>())
        {
            bool playerFound = Physics.Raycast(transform.position, other.transform.position - transform.position, out RaycastHit hit, eyesightSizeTargeted);
            
            if (!playerFound) return;
            
            if (hit.transform.gameObject.GetComponent<Player>())
            {
                target = other.gameObject;
                isFollowing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            isFollowing = false;
        }
    }
    private void Update()
    {
        if (isFollowing)
        {
            SetAgent(target.transform.position, eyesightLocationTargeted, eyesightSizeTargeted);
        }
        else
        {
            SetAgent(originalPosition, eyesightLocationOriginal, eyesightSizeOriginal);
        }
    }

    void SetAgent(Vector3 pTarget, Vector3 pEyeSightLocation, float pEyesightSize)
    {
        agent.destination = pTarget;
        sphereCollider.center = pEyeSightLocation;
        sphereCollider.radius = pEyesightSize;
    }
}
