using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMvt : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.5f;
        animator.SetFloat("Speed",movement);
        transform.position += Time.deltaTime * movement * 4 * Vector3.forward;
    }
}
