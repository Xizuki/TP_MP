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
        
    }

    // Update is called once per frame
    void Update()
    {
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
