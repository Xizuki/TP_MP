using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public SphereCollider colliderInv;
    public ParticleSystem explosion;

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
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "ChestEnemy")
        {
            if (other.gameObject.tag == "ChestEnemy")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
            Object.Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }
}
