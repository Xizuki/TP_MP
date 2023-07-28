using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public SphereCollider colliderInv;

    private void Start()
    {
        colliderInv.enabled = false;
    }

    private void FixedUpdate()
    {
        if (jumpingPlayer.jumpChargePrev >= 0.9 && jumpingPlayer.isJumping == true)
        {
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability()
    {
        colliderInv.enabled = true;
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Works");
        colliderInv.enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            Destroy(other.gameObject);
    }
}
