using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallBullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float shootForce = 10f;
    public float shootAngle = 45f;

    private void Update()
    {
        float timer = 2;
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            ShootProjectile();
            timer = 2;
        }
    }

    private void ShootProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();


        // Apply an impulse force to the projectile
        projectileRigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
    }
}
