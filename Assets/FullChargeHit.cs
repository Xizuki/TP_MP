using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullChargeHit : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public GameObject raycastLine;
    public GameObject raycastLine2;
    public Camera mainCamera;
    public int distanceSet;
    RaycastHit hit;
    RaycastHit hit2;
    private Vector3 flyDir;

    private void Start()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Platform" && jumpingPlayer.jumpChargePrev >= 0.9)
        {
            Physics.Raycast(raycastLine.transform.position, raycastLine.transform.right, out hit,  distanceSet);
            if (hit.collider == null)
            {
                return;
            }
            if(hit.collider.tag == "Enemy")
            {
                Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);
            }
            Physics.Raycast(raycastLine.transform.position, -raycastLine.transform.right,out hit2, distanceSet);

            if (hit2.collider == null)
            {
                return;
            }
            if (hit2.collider.tag == "Enemy")
            {
                Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                hit2.rigidbody.AddForce(flyDir, ForceMode.Impulse);
            }
            else
            {
            }
        }
        if (collision.collider.tag == "Platform" && jumpingPlayer.jumpChargePrev >= 0.9)
        {
            Physics.Raycast(raycastLine2.transform.position, raycastLine2.transform.right, out hit, distanceSet);
            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.tag == "Enemy")
            {
                Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);
            }
            Physics.Raycast(raycastLine2.transform.position, -raycastLine2.transform.right, out hit2, distanceSet);

            if (hit2.collider == null)
            {
                return;
            }
            if (hit2.collider.tag == "Enemy")
            {
                Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                hit2.rigidbody.AddForce(flyDir, ForceMode.Impulse);
            }
            else
            {
            }
        }
    }
}
