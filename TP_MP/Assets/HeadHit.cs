using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHit : MonoBehaviour
{
    public MushroomEnemy mushroomEnemy;
    public ParticleSystem explosionDeath;
    public GameObject mushroom;
    public Animator animator;
    public PatrolCheck patrolCheck;
    public SkinnedMeshRenderer skinned;

    private void Start()
    {
        mushroomEnemy = GetComponentInParent<MushroomEnemy>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Die");
            explosionDeath.Play();
            patrolCheck.enabled = false;
            skinned.enabled = false;
            mushroomEnemy.Die();
            mushroomEnemy.BouncePlayer(collision.gameObject.GetComponent<JumpingPlayerScript>());
        }
    }
}
