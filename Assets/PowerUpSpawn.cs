using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public Transform[] powerUpSpawns;
    public GameObject[] powerUp;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }

    void Spawn()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        for (int i = 0; i < powerUpSpawns.Length; i++) //for loop for each item in array list spikeSpawns
        {
            int coinFlip = Random.Range(0, 10); //randomise spawn between 0 and 5
            int enemyno = Random.Range(0, 2);
            if (coinFlip > 7)
            {
                Vector3 allignedPosition = new Vector3(powerUpSpawns[i].position.x, transform.position.y + 1.5f, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(powerUp[enemyno], allignedPosition, Quaternion.Euler(direction)));

                //Spawn GameObject Spike at spikeSpawns position
            }
        }
    }

}
