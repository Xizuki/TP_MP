using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [Header("Speed")]
    public float baseSpeed;

    public float speed;

    [Header("Multipliers")]

    [SerializeField]
    private float currentMultiplier = 1f;

    [SerializeField]
    private float easyMultiplier = 1f;

    [SerializeField]
    private float mediumMultiplier = 1.5f ;

    [SerializeField]
    private float hardMultiplier = 2f;



    [Header("Stuff")]
    public ParticleSystem explosion;
    public ParticleSystem aura;
    public Collider bulletCollider;
    public int destroyTimer;

    [Header("Dictionary")]

    [SerializeField]
    private Dictionary_GameplaySettings dictionary;


    private void Awake()
    {
        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();
    }

    private void Start()
    {
        if (!FindObjectOfType<Dictionary_GameplaySettings>())
        {
            currentMultiplier = easyMultiplier;
        }

        if (dictionary.GameplaySettings["EnemyProjectileSpeed"] == Difficulty.Easy)
        {
            currentMultiplier = easyMultiplier;
        }

        else if (dictionary.GameplaySettings["EnemyProjectileSpeed"] == Difficulty.Medium)
        {
            currentMultiplier = mediumMultiplier;
        }

        else if (dictionary.GameplaySettings["EnemyProjectileSpeed"] == Difficulty.Hard)
        {
            currentMultiplier = hardMultiplier;
        }
    }


    private void Update()
    {
        FlyBullet();
        Destroy(gameObject, destroyTimer);
    }

    public void FlyBullet()
    {
        Debug.Log("Current Multiplier: " + currentMultiplier);
        transform.position += (transform.forward* speed* currentMultiplier * Time.deltaTime);
        if (bulletCollider.enabled == false)
        {
            transform.position += (-transform.forward * speed* currentMultiplier* Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<ShieldPowerUp>().isActivated)
            {
                return;
            }
        }

        //Debug.Log("Hit");

        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
