using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    private GameObject shiba;
    public Animator anim;
    public GameObject shield;
    public ParticleSystem equipParticle;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject child1 = other.gameObject.transform.GetChild(1).gameObject;
            GameObject child1of2 = child1.gameObject.transform.GetChild(0).gameObject;
            GameObject child1of2of3 = child1of2.gameObject.transform.GetChild(1).gameObject;
            shiba = child1of2of3;
            shiba.SetActive(true);
            anim.SetTrigger("PickUp");
            equipParticle.Play();
            Destroy(shield);
        }
    }
}
