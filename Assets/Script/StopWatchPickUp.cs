using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchPickUp : MonoBehaviour
{
    StopWatchPowerUp powerUp;
    public GameObject grayEffects; //an image that acts as background effect when stopwatch is picked up

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

            

            grayEffects.SetActive(true);

            if (powerUp.isActivated)
            {
                SFX.stopwatchPickOn = true;
            }
        }
    }
}
