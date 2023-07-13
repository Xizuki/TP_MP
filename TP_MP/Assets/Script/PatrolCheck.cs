using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCheck : MonoBehaviour
{
    public float baseSpeed;
    public float speed;
    public float distance;
    private bool movingRight = true;
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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out groundInfo, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -270, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
                movingRight = true;
            }
        }

        if(hit == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Debug.Log("time");
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
