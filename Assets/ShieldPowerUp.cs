using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUpScript
{
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