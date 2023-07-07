using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            CameraShaker.Invoke(5); //To set if screenshake is turned on
            Debug.Log("Hit");
        }
    }
}
