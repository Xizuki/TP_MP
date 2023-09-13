using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableJump : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public SphereCollider colliderInv;

    public ParticleSystem explosion;

    public Outline outlineScript;
    public float outlineWidth = 0f;

    public bool chargeInitial;

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

        if (jumpingPlayer.isJumping == true || JumpingPlayerScript.fullyCharge == true)
        {
            
            if (outlineScript.OutlineWidth < outlineWidth)
            {
                if (chargeInitial == false)
                {
                    outlineScript.OutlineWidth = 1f;
                    chargeInitial = true;
                }
                outlineScript.OutlineWidth += 0.35f;
            }
            else if (outlineScript.OutlineWidth >= outlineWidth)
            {
                outlineScript.OutlineWidth = outlineWidth;
            }
        }


        if (jumpingPlayer.isJumping == false && JumpingPlayerScript.fullyCharge == false)
        {
            chargeInitial = false;
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
        Debug.Log("Works");
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "ChestEnemy")
        {
            if (other.gameObject.tag == "ChestEnemy")
            {
                Destroy(other.gameObject);
                Destroy(other.gameObject.transform.parent.gameObject);

            }
            else
            {
                Destroy(other.gameObject);
            }
            Object.Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }
}
