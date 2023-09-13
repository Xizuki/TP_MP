using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemySpawns;
    public GameObject[] enemy;

    [SerializeField]
    private Dictionary_GameplaySettings dictionary;
    int easy = 10;

    int medium = 12;

    int hard = 15;

    public bool rotationalOverride;
    public bool spawned;
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

        print("Spawn");
        if (FindObjectOfType<Dictionary_GameplaySettings>() == null)
        {


            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {
                Vector3 forward = Vector3.zero - new Vector3( enemySpawns[i].position.x,0,0);

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlip = Random.Range(0, easy); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);

                //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z) ;


                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                    GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count-1].transform.forward = forward;
                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (   dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Easy)
        {
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {
                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is easy!"  );
                int coinFlip = Random.Range(0, easy); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);

                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                    GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Medium)
        {
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {
                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is Medium!");
                int coinFlip = Random.Range(0, medium); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);

                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y +1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                    GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Hard)
        {
            Debug.Log("Enemy spawn frequency is Hard!");
            for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
            {
                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                int coinFlip = Random.Range(0, hard); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, 2);

                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (coinFlip > 7)
                {
                    GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                    GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;

                    //Spawn GameObject Spike at spikeSpawns position
                }
            }
        }
    }

}
