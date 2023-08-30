using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemySpawns;
    public GameObject[] enemy;

    [SerializeField]
    private Dictionary_GameplaySettings dictionary;
    int easy = 12;

    int medium = 10;

    int hard = 8;

    private void Awake()
    {
        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }

    void Spawn()
    {
        Vector3 direction = new Vector3(0, 90, 0);

        if (FindObjectOfType<Dictionary_GameplaySettings>() == null)
        {
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlip = Random.Range(0, easy); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);
                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], enemySpawns[i].position, enemySpawns[i].rotation));

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Easy)
        {
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {

                Debug.Log("Enemy spawn frequency is easy!"  );
                int coinFlip = Random.Range(0, easy); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);
                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], enemySpawns[i].position, enemySpawns[i].rotation));

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Medium)
        {
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {

                Debug.Log("Enemy spawn frequency is Medium!");
                int coinFlip = Random.Range(0, medium); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);
                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], enemySpawns[i].position, enemySpawns[i].rotation));

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Hard)
        {
            Debug.Log("Enemy spawn frequency is Hard!");
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {
                int coinFlip = Random.Range(0, hard); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);
                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], enemySpawns[i].position, enemySpawns[i].rotation));

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }
    }

}
