using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHittableObject : MonoBehaviour
{

    [SerializeField] bool hasHitRB = false;
    GameObject lastHitObject = null;
    Transform parentRB;

    private void Start()
    {
        parentRB = transform.GetComponentInParent<Rigidbody>().transform;

        foreach (BoxCollider bc in parentRB.GetComponentsInChildren<BoxCollider>())
            foreach (SphereCollider sc in parentRB.GetComponents<SphereCollider>())
                Physics.IgnoreCollision(sc, bc);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.isTrigger) { return; }

        if (other.GetComponent<Hittable>())
        {
            lastHitObject = other.gameObject;
            hasHitRB = true;
        }
    }

    public bool GetHitState()
    {
        return hasHitRB;
    }

    public void SetHitState(bool pState)
    {
        hasHitRB = pState;
    }

    public GameObject GetHittenObject()
    {
        return lastHitObject;
    }
}
