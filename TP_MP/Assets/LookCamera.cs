using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public Transform playerHeadTransform;
    public Transform cameraPosition;
    public Vector3 vector;
    public float playerHeadLookUpAngleLimit;
    public float x;
    public float y;
    public float z;

    private void LateUpdate()
    {
        /*vector = (cameraPosition.transform.position - playerHeadTransform.transform.position);
        playerHeadTransform.up = new Vector3(-vector.x, -vector.y, -vector.z);

        playerHeadTransform.eulerAngles += new Vector3(x, y, z);*/

        transform.LookAt(new Vector3 (cameraPosition.position.x + x, cameraPosition.position.y + y, cameraPosition.position.z + z), playerHeadTransform.forward);
    }
}
