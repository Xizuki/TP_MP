using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public GameObject colliderInv;

    private void Start()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>();
    }

    private void Update()
    {
        if(jumpingPlayer.isJumping == true && jumpingPlayer.jumpChargePrev >= 0.9)
        {
            Invulnerability();
        }
    }

    public void Invulnerability()
    {
        colliderInv.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            Destroy(other.gameObject);
    }
}
