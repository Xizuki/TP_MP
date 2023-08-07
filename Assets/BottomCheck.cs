using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCheck : MonoBehaviour
{
    public float baseSpeed;
    public Quaternion turtleRotation;
    public float speed;
    public float distance;
    private float timer = 1.5f;
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
        if (groundInfo.collider == false)
        {
            transform.eulerAngles = new Vector3(turtleRotation.x - 90, turtleRotation.y = 90, turtleRotation.z = 180);
        }

        if (hit == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            speed = 5f;
            timer = 1.3f;
            hit = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Attack");
            animator.SetTrigger("Attack");
            speed = 0f;
        }
    }
}
