using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    public GameObject camPosition1;
    public GameObject camPosition2;
    public GameObject camPosition3;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable timeSinceLastShot()
    {
        yield return new WaitForSeconds(3f);
    }
}
