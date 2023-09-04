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

    RaycastHit[] allHit;
    RaycastHit[] allHit2;
    private Vector3 flyDir;

    private void Start()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>();
    }

    private void Update()
    {

    }

    public void Landing(Collision collision)
    {

        if (collision.collider.tag == "Platform" && jumpingPlayer.jumpChargePrev >= 0.9)
        {
            Debug.DrawRay(raycastLine.transform.position, raycastLine.transform.right * distanceSet, Color.red, 1000f);
            Debug.DrawRay(raycastLine2.transform.position, raycastLine2.transform.right * distanceSet, Color.blue, 1000f);

            allHit = Physics.RaycastAll(raycastLine.transform.position, raycastLine.transform.right, distanceSet);
            allHit2 = Physics.RaycastAll(raycastLine.transform.position, -raycastLine.transform.right, distanceSet);

            foreach(RaycastHit hit in allHit)
            {
                if (hit.collider == null)
                {
                    //return;
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);

                    print("ASDASDASFASFASF");
                }
            }
            foreach (RaycastHit hit in allHit2)
            {
                if (hit.collider == null)
                {
                    //return;
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);

                    print("ASDASDASFASFASF");
                }
            }


            if (Physics.Raycast(raycastLine.transform.position, raycastLine.transform.right, out hit, distanceSet))
            {
                if (hit.collider == null)
                {
                    //return;
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);

                    print("ASDASDASFASFASF");
                }
            }
            if (Physics.Raycast(raycastLine.transform.position, -raycastLine.transform.right, out hit, distanceSet))
            {
                if (hit2.collider == null)
                {
                    //return;
                }
                else if (hit2.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit2.rigidbody.AddForce(flyDir, ForceMode.Impulse);
                    print("ASDASDASFASFASF");

                }
                else
                {
                }
            }
        }
        if (collision.collider.tag == "Platform" && jumpingPlayer.jumpChargePrev >= 0.9)
        {

            allHit = Physics.RaycastAll(raycastLine.transform.position, raycastLine.transform.right, distanceSet);
            allHit2 = Physics.RaycastAll(raycastLine.transform.position, -raycastLine.transform.right, distanceSet);

            foreach (RaycastHit hit in allHit)
            { 
                if (hit.collider == null)
                {
                    //return;
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);

                    print("ASDASDASFASFASF");
                }
            }
            foreach (RaycastHit hit in allHit2)
            {
                if (hit.collider == null)
                {
                    //return;
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);

                    print("ASDASDASFASFASF");
                }
            }



            if (Physics.Raycast(raycastLine2.transform.position, raycastLine2.transform.right, out hit, distanceSet))
            {
                if (hit.collider == null)
                {
                    return;
                }
                else if(hit.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit.rigidbody.AddForce(flyDir, ForceMode.Impulse);
                    print("ASDASDASFASFASF");

                }
            }
            if (Physics.Raycast(raycastLine2.transform.position, -raycastLine2.transform.right, out hit2, distanceSet))
            {
                if (hit2.collider == null)
                {
                    //return;
                }
                else if (hit2.collider.tag == "Enemy")
                {
                    Vector3 camDir = mainCamera.transform.position - hit.transform.position;
                    flyDir = new Vector3(camDir.x, camDir.y, camDir.z);
                    hit2.rigidbody.AddForce(flyDir, ForceMode.Impulse);
                    print("ASDASDASFASFASF");

                }
                else
                {
                }
            }
        }
    }
}
