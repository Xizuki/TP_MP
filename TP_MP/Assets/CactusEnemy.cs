using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusEnemy : EnemyScript
{
    public CactusShoot cactusShoot;
    // Start is called before the first frame update
    void Start()
    {
        cactusShoot = GetComponentInChildren<CactusShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
