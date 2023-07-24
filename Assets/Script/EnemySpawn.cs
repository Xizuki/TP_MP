using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemySpawns;
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }

    void Spawn()
    {
        Vector3 direction = new Vector3(0,90,0);
        for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
        {
            int coinFlip = Random.Range(0, 10); //randomise spawn between 0 and 5
            int enemyno = Random.Range(0, 2);
            if (coinFlip > 7) 
            {
                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], enemySpawns[i].position, enemySpawns[i].rotation));

                //Spawn GameObject Spike at spikeSpawns position
            }
        }
    }

}
