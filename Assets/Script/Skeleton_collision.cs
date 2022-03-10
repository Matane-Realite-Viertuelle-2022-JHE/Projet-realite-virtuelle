using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_collision : MonoBehaviour
{
    public SkeletonBehavior squeleton;
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            squeleton = GetComponent<SkeletonBehavior>();
            squeleton.TakeDamage(10);
            print("Enter");
        }
    } 
    
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("Stay");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("Exit");
        }
    }

    private void Update()
    {
        
    }
}
