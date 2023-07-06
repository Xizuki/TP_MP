using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusShoot : MonoBehaviour
{
    public float shootDelayTimer = 3f;
    public GameObject bullet;
    public GameObject cactus;

    private void Start()
    {
        StartCoroutine(ShootDelay());
    }
    private void Update()
    {
        ShootDelay();
    }

    IEnumerator ShootDelay()
    {

        WaitForSeconds waitTime = new WaitForSeconds(shootDelayTimer);
        while (true)
        {
            GameObject.Instantiate(bullet, transform.position, cactus.transform.rotation);
            yield return waitTime;
        }
    }
}
