using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject shibaKnight;
    public Vector3 heroPosition;
    public List<GameObject> spawnRoom;
    public GameObject spawnTop;
    public float spawnBottom = 80f;


    // Start is called before the first frame update
    void Start()
    {
        heroPosition = shibaKnight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        heroPosition = shibaKnight.transform.position;
        if (heroPosition.y > (spawnTop.transform.position.y) - spawnBottom)
        {
            spawnTop = GameObject.Instantiate(spawnRoom[0], spawnTop.transform.position,
            spawnTop.transform.rotation).GetComponentInChildren<SpawnTopScript>().gameObject;

        }
    }
}
