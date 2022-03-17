using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollisionDetection : MonoBehaviour
{
    XRGrabInteractable xrGrab;

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
