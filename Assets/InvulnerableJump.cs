using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public SphereCollider colliderInv;

    private void Start()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>();
        StartCoroutine(Invulnerability());
    }

    private void Update()
    {
        if(jumpingPlayer.isJumping == true && jumpingPlayer.jumpChargePrev >= 0.9)
        {
            Invulnerability();
        }
    }

    private IEnumerator Invulnerability()
    {
        colliderInv.enabled = !colliderInv.enabled;
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Works");
        colliderInv.enabled = colliderInv.enabled;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            Destroy(other.gameObject);
    }
}
