using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollionDetection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log(other.name);
            other.GetComponent<SkeletonBehavior>().TakeDamage(100);
        }
    }
}
