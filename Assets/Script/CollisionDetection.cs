using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollisionDetection : MonoBehaviour
{
    XRGrabInteractable xrGrab;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        xrGrab = GetComponent<XRGrabInteractable>();

    }

    private void Update()
    {
        if (xrGrab.isSelected)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy")
        {
            xrGrab = GetComponent<XRGrabInteractable>();
            Debug.Log(xrGrab.isSelected);
            Debug.Log(other.name);
            other.GetComponent<SkeletonBehavior>().TakeDamage(100);
        }
    }
}
