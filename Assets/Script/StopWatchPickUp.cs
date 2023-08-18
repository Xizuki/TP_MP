using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchPickUp : MonoBehaviour
{
    StopWatchPowerUp powerUp;

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

            SFX.stopwatchPickSound = true;


            if (powerUp.isActivated)
            {
                SFX.stopwatchPickOn = true;
                PickUpPowerup.stopwatch = true;
            }
        }
    }
}
