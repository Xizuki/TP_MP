using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUpScript
{
    public override void Effect()
    {
        base.Effect();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "EnemyBullet") { return; }

        if(!isActivated) { return; }
        collision.gameObject.tag = "PlayerBullet";

        collision.gameObject.transform.forward = -collision.gameObject.transform.forward;
    }
}