using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchPickUp : MonoBehaviour
{
    StopWatchPowerUp powerUp;
    public ParticleSystem clockVFX;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            powerUp = other.gameObject.GetComponent<StopWatchPowerUp>();
            Destroy(gameObject);
            powerUp.isActivated = true;
            powerUp.timer = 10f;
            GameObject.Instantiate(clockVFX, transform.position, transform.rotation);

            SFX.stopwatchPickSound = true;


            if (powerUp.isActivated)
            {
                SFX.stopwatchPickOn = true;
                PickUpPowerup.stopwatch = true;
            }
        }
    }
}
