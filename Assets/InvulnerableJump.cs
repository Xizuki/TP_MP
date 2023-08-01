using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public SphereCollider colliderInv;
    public Outline outlineScript;

    private void Start()
    {
        colliderInv.enabled = false;
        //outlineScript.enabled = false;
    }

    private void FixedUpdate()
    {
        if (jumpingPlayer.jumpChargePrev >= 0.9 && jumpingPlayer.isJumping == true)
        {
            StartCoroutine(Invulnerability());
        }

        if (jumpingPlayer.isJumping == true)
        {
            outlineScript.OutlineWidth = 5f;
        }
        if (jumpingPlayer.isJumping == false)
        {
            outlineScript.OutlineWidth -= 0.35f;
            
            if (outlineScript.OutlineWidth < 0)
            {
                outlineScript.OutlineWidth = 0f;
            }

        }

    }

    IEnumerator Invulnerability()
    {
        colliderInv.enabled = true;
        //outlineScript.enabled = true;

        yield return new WaitForSeconds(1.0f);
        colliderInv.enabled = false;
        //outlineScript.enabled = false;
        outlineScript.OutlineWidth += 0.15f;
        Debug.Log("Works");
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            Destroy(other.gameObject);
    }
}
