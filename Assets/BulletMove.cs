using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float baseSpeed;
    public float speed;
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
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<ShieldPowerUp>().isActivated)
            {
                return;
            }
        }


        Debug.Log("Hit");
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        StartCoroutine(DestroyBullet());

        IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(8.0f);
            Destroy(gameObject);
        }
    }
}
