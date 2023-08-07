using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseBullet : MonoBehaviour
{
    public Rigidbody bulletRB;
    //public ParticleSystem snowballLand;
    void Start()
    {
        bulletRB.AddForce(transform.position, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<ShieldPowerUp>().isActivated)
            {
                return;
            }
        }
        //Instantiate(snowballLand, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
