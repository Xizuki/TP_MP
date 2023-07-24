using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusShoot : MonoBehaviour
{
    public float baseShootDelayTimer;
    public float shootDelayTimer;
    public GameObject bullet;
    public GameObject cactus;
    public Animator animator;

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
            animator.SetTrigger("Attack");
            GameObject.Instantiate(bullet, transform.position, cactus.transform.rotation);
            yield return waitTime;
        }
    }
}
