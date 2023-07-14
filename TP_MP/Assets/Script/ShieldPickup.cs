using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public GameObject shiba;
    public GameObject shield;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            shiba.SetActive(true);
            Destroy(shield);
        }
    }
}
