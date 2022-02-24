using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMvt : MonoBehaviour
{
    Animator animator;
    Transform playerHead;
    public float rotateSpeed = 1f;
    public float movementSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHead = GameManager.instance.PlayerHead;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed",movementSpeed);
        Vector3 headPos = new Vector3(playerHead.position.x, transform.position.y, playerHead.position.z);
        Vector3 headDirection = headPos - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(headDirection, Vector3.up),Time.deltaTime * rotateSpeed);
        transform.position += Time.deltaTime * movementSpeed * 2 * transform.forward;

        Debug.Log(GameManager.instance.PlayerHead.position);
    }
}
