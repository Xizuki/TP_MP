using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{
    public Animator bAnimator;
    public RaycastHit hit;
    public GameObject eye;
    public GameObject bullet;
    public bool eyeShoot = false;
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
        Debug.Log("Scan");
        Debug.DrawRay(eye.transform.position, -eye.transform.up, Color.red);
        Physics.Raycast(eye.transform.position, -eye.transform.up, out hit, Mathf.Infinity);
        if (hit.collider == null)
        {
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
                Instantiate(bullet, eye.transform.position, transform.rotation);
                yield return new WaitForSeconds(1.2f);
            }
        }
    }
}
