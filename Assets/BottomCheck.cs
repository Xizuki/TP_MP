using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCheck : MonoBehaviour
{
    public float baseSpeed;
    public Quaternion turtleRotation;
    public float speed;
    public float distance;
    private bool hit = false;

    public Transform groundCheck;

    private Animator animator;

    RaycastHit groundInfo;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        turtleRotation = transform.rotation;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out groundInfo, distance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);
        hit = groundInfo.collider;
        Debug.Log(hit);
        if (groundInfo.collider == false)
        {
            transform.Rotate(90, 0, 0);
        }

    }
}
