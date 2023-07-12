using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public GameObject shiba;
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
            shiba.SetActive(true);
            anim.SetTrigger("PickUp");
            equipParticle.Play();
            Destroy(shield);
        }
    }
}
