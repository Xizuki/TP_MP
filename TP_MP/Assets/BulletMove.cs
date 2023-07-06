using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public int speed = 5;
    public ParticleSystem explosion;
    public ParticleSystem aura;
    public MeshRenderer bulletMesh;
    public SphereCollider bulletCollider;

    private void Update()
    {
        FlyBullet();
    }

    public void FlyBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (bulletCollider.enabled == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        explosion.Play();
        bulletMesh.enabled = false;
        bulletCollider.enabled = false;
        aura.Stop();
    }
}
