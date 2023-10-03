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
        RaycastHit hit;
        Physics.Raycast(groundCheck.position, -transform.up, out hit, distance,LayerMask.GetMask("Default"));

        if (hit.collider == null)
        {
            transform.Rotate(7.5f * speed, 0, 0) ;
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //turtleRotation = transform.rotation;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out groundInfo, distance);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);
        //hit = groundInfo.collider;
        //Debug.Log(hit);
        //if (groundInfo.collider == false)
        //{
        //    transform.Rotate(90, 0, 0);
        //}

    }
}
