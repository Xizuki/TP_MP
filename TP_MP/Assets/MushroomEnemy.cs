using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemy : EnemyScript
{
    public PatrolCheck patrolCheck;
    public override void Die()
    {
        base.Die();
    }

    public void BouncePlayer(JumpingPlayerScript player)
    {
        player.rb.velocity = Vector3.zero;
        player.isGrounded = true;
        player.jumpCharge = 0.2f;
        player.Jump();
    }
    // Start is called before the first frame update
    void Start()
    {
        patrolCheck = GetComponent<PatrolCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
