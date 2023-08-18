using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPowerUp : PowerUpScript
{
    public ParticleSystem auraShield;
    public Image sliderFill;
    public float delay = 0;
    public float timer;

    private void Update()
    {
        if(isActivated == true)
        {
            sliderFill.fillAmount = 1;
            sliderFill.fillAmount = timer / 10;
            timer -= Time.deltaTime;
            if (timer < delay)
            {
                isActivated = false;
                timer = 10f;
                sliderFill.fillAmount = 0;
                auraShield.Stop();
            }
        }
    }
    public override void Effect()
    {
        base.Effect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EnemyBullet") { return; }

        if (!isActivated) { return; }
        other.gameObject.tag = "PlayerBullet";

        other.gameObject.transform.forward = -other.gameObject.transform.forward;
    }
}