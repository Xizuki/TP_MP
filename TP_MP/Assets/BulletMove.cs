using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject cactus;
    public int speed = 5;

    private void Update()
    {
        FlyBullet();
    }

    public void FlyBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
