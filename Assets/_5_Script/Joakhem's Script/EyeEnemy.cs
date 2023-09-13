using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy : EnemyScript
{
    public Animator bAnimator;
    public RaycastHit hit;
    public GameObject eye;
    public GameObject bullet;
    public bool eyeShoot; //= false;
    void Start()
    {
        GameObject gameObject = transform.GetChild(1).gameObject;
        GameObject gameObject2 = gameObject.transform.GetChild(0).gameObject;
        GameObject gameObject3 = gameObject2.transform.GetChild(1).gameObject;
        //eye = gameObject3.transform.GetChild(0).gameObject;
        StartCoroutine(ShootBullet());

    }

    void Update()
    {
        Debug.DrawRay(eye.transform.position, transform.forward, Color.red);
        Physics.Raycast(eye.transform.position, transform.forward, out hit, Mathf.Infinity);
        if (hit.collider == null)
        {
            eyeShoot = false;
            return;
        }
        else if (hit.collider.tag == "Player")
        {
            eyeShoot = true;
        }
        else
        {
            eyeShoot = false;
        }


    }

    IEnumerator ShootBullet()
    {
        while (true)
        {
            if (eyeShoot)
            {
                bAnimator.SetTrigger("Attack");
                yield return new WaitForSeconds(1.2f);
                GameObject GO = Instantiate(bullet, eye.transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z));
                GO.transform.forward = transform.forward;
                GO.GetComponent<BulletMove>().owner = gameObject;
            }
            yield return null;
        }
    }
}
