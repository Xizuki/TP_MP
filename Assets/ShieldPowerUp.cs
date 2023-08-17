using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPowerUp : PowerUpScript
{
    public ParticleSystem auraShield;
    public Image sliderFill;
    public float delay = 0;
    public GameObject shieldVfx;
    public GameObject shieldIconVfx;
    float timer = 10f;

    private void Start()
    {
        shieldIconVfx.SetActive(false);
    }

    private void Update()
    {
        if(isActivated == true)
        {
            sliderFill.fillAmount = 1;
            sliderFill.fillAmount = timer / 10;
            timer -= Time.deltaTime;
            shieldVfx.SetActive(true);
            shieldIconVfx.SetActive(true);
            if (timer < delay)
            {
                shieldVfx.SetActive(false);
                isActivated = false;
                timer = 10f;
                sliderFill.fillAmount = 0;
                auraShield.Stop();
                shieldIconVfx.SetActive(false);
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