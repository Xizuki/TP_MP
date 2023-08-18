using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeCheck : MonoBehaviour
{

    public bool collided = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Platform"))
        {

           Debug.Log("Collided with platform!");
           collided = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Platform"))
        {


            Debug.Log("Stop colliding with platform!");
            collided = false;

        }
    }
}
