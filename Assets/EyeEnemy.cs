using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator ShootBullet()
    {
        yield return new WaitForSeconds(3f);
    }
}
