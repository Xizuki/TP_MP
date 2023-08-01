using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEnemy : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject raycastLine;
    public BoxCollider boxCollider;
    public int distanceSet;
    public RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = transform.GetChild(1).gameObject;
        GameObject gameObject2 = gameObject.transform.GetChild(0).gameObject;
        GameObject gameObject3 = gameObject2.transform.GetChild(2).gameObject;
        GameObject gameObject4 = gameObject3.transform.GetChild(0).gameObject;
        raycastLine = gameObject4.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (raycastLine == null)
        {
            return;
        }
            Physics.Raycast(raycastLine.transform.position, -raycastLine.transform.up, out hit, distanceSet);
        Debug.DrawRay(raycastLine.transform.position, -raycastLine.transform.up, Color.red);
        if (hit.collider == null)
        {
            return;
        }
        else if (hit.collider.tag == "Player")
        {
            chestAnimator.SetTrigger("Scan");
        }
    }
}
