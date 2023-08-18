using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    private GameObject shiba;
    public Animator anim;
    public GameObject shield;
    public ParticleSystem equipParticle;
    public ParticleSystem auraShield;
    public ShieldPowerUp shieldPowerUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shieldPowerUp = other.gameObject.GetComponent<ShieldPowerUp>();
            shieldPowerUp.isActivated = true;
            shieldPowerUp.timer = 10f;

            GameObject child1 = other.gameObject.transform.GetChild(1).gameObject;
            GameObject child1of2 = child1.gameObject.transform.GetChild(0).gameObject;
            GameObject child1of2of3 = child1of2.gameObject.transform.GetChild(1).gameObject;
            equipParticle = other.transform.GetChild(5).GetComponentInChildren<ParticleSystem>();
            auraShield = other.transform.GetChild(8).GetComponentInChildren<ParticleSystem>();
            anim = other.transform.GetChild(1).GetComponentInChildren<Animator>();

            shiba = child1of2of3;
            shiba.SetActive(true);
            anim.SetTrigger("PickUp");
            equipParticle.Play();
            auraShield.Play();
            Destroy(this.gameObject);

            SFX.shieldPick = true;
        }
    }
}