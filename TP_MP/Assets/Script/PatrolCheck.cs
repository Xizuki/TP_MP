using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCheck : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundCheck;

    RaycastHit groundInfo;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out groundInfo, distance);
        if(groundInfo.collider == false)
        {
            Debug.Log("Change");
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
    }
}
