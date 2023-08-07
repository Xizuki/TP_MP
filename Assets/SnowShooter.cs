using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowShooter : MonoBehaviour
{
    public GameObject mouth;
    public GameObject bullet;
    public float timer;

    void Start()
    {
    }


    void Update()
    {
        StartCoroutine(ShootSnowball());
    }

    private IEnumerator ShootSnowball()
    {
        yield return new WaitForSeconds(timer);
        Instantiate(bullet, mouth.transform.position, mouth.transform.rotation);
    }
}
