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
    float easyMin = 0.15f;
    float easyMax = 0.25f;

    float mediumMin = 0.3f;
    float mediumMax = 0.5f;

    float hardMin = 0.55f;
    float hardMax = 0.75f;


    public bool overrideY;

    public bool rotationalOverride;
    public bool spawned;

    public GameObject mob;
    private void Awake()
    {
        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    [ContextMenu("Spawn Enemy")]
    void ForcedSpawn()
    {
        for (int i = 0; i < enemySpawns.Length; i++) //for loop for each item in array list spikeSpawns
        {
            Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

            Debug.Log("Enemy spawn frequency is easy!");
            int enemyno = Random.Range(0, enemy.Length);

            //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
            Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

            if (!overrideY)
                allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);


            GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
            GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;
            //Spawn GameObject Spike at spikeSpawns position

        }
    }
    void Spawn()
    {
        if (FindObjectOfType<Dictionary_GameplaySettings>() == null)
        {
            float ran = Random.Range(easyMin,easyMax);
            int enemySpawnLocations = enemySpawns.Length;
            int enemiesToSpawn =  Mathf.RoundToInt(enemySpawnLocations * ran);

            List<int> indexLocationSpawned = new List<int>();

            for (int i = 0; i < enemiesToSpawn; i++) //for loop for each item in array list spikeSpawns
            {
                foreach(int index in indexLocationSpawned)
                {
                    if(index == i)
                    {
                        i--;
                        continue;
                    }
                }

                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlipLocation = Random.Range(0, enemySpawnLocations); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, enemy.Length);

                //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (!overrideY)
                    allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);


                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;
                //Spawn GameObject Spike at spikeSpawns position
                indexLocationSpawned.Add(coinFlipLocation);
            }
        }

        else if (   dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Easy)
        {
            float ran = Random.Range(easyMin, easyMax);
            int enemySpawnLocations = enemySpawns.Length;
            int enemiesToSpawn = Mathf.RoundToInt(enemySpawnLocations * ran);

            List<int> indexLocationSpawned = new List<int>();

            for (int i = 0; i < enemiesToSpawn; i++) //for loop for each item in array list spikeSpawns
            {
                foreach (int index in indexLocationSpawned)
                {
                    if (index == i)
                    {
                        i--;
                        continue;
                    }
                }

                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlipLocation = Random.Range(0, enemySpawnLocations); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, enemy.Length);

                //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (!overrideY)
                    allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);


                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;
                //Spawn GameObject Spike at spikeSpawns position
                indexLocationSpawned.Add(coinFlipLocation);
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Medium)
        {
            float ran = Random.Range(mediumMin, mediumMax);
            int enemySpawnLocations = enemySpawns.Length;
            int enemiesToSpawn = Mathf.RoundToInt(enemySpawnLocations * ran);

            List<int> indexLocationSpawned = new List<int>();

            for (int i = 0; i < enemiesToSpawn; i++) //for loop for each item in array list spikeSpawns
            {
                foreach (int index in indexLocationSpawned)
                {
                    if (index == i)
                    {
                        i--;
                        continue;
                    }
                }

                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlipLocation = Random.Range(0, enemySpawnLocations); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, enemy.Length);

                //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (!overrideY)
                    allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);


                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;
                //Spawn GameObject Spike at spikeSpawns position
                indexLocationSpawned.Add(coinFlipLocation);
            }
        }

        else if (dictionary.GameplaySettings["EnemySpawnFrequency"] == Difficulty.Hard)
        {
            Debug.Log("Enemy spawn frequency is Hard!");
            float ran = Random.Range(hardMin, hardMax);
            int enemySpawnLocations = enemySpawns.Length;
            int enemiesToSpawn = Mathf.RoundToInt(enemySpawnLocations * ran);

            List<int> indexLocationSpawned = new List<int>();

            for (int i = 0; i < enemiesToSpawn; i++) //for loop for each item in array list spikeSpawns
            {
                foreach (int index in indexLocationSpawned)
                {
                    if (index == i)
                    {
                        i--;
                        continue;
                    }
                }

                Vector3 forward = Vector3.zero - new Vector3(enemySpawns[i].position.x, 0, 0);

                Debug.Log("Enemy spawn frequency is easy!");
                int coinFlipLocation = Random.Range(0, enemySpawnLocations); //randomise spawn between 0 and 5
                int enemyno = Random.Range(0, enemy.Length);

                //Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, enemySpawns[i].position.z);
                Vector3 allignedPosition = new Vector3(enemySpawns[i].position.x, enemySpawns[i].position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

                if (!overrideY)
                    allignedPosition = new Vector3(enemySpawns[i].position.x, transform.position.y + 1.15f, GameObject.FindGameObjectWithTag("Player").transform.position.z);


                GetComponent<PlatformScript>().enemiesOnPlatform.Add(Instantiate(enemy[enemyno], allignedPosition, enemySpawns[i].rotation));
                GetComponent<PlatformScript>().enemiesOnPlatform[GetComponent<PlatformScript>().enemiesOnPlatform.Count - 1].transform.forward = forward;
                //Spawn GameObject Spike at spikeSpawns position
                indexLocationSpawned.Add(coinFlipLocation);
            }
        }
    }

}
