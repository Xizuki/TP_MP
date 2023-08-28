using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject shibaKnight;
    public Vector3 heroPosition;
    public GameObject spawnTop;
    public int roomType;
    public List<GameObject> spawnRoom;
    public float spawnBottom = 80f;
    public int spawnedRooms = 0;

    void Start()
    {
        heroPosition = shibaKnight.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        heroPosition = shibaKnight.transform.position;
        if (heroPosition.y > (spawnTop.transform.position.y) - spawnBottom)
        {
            RoomSpawn();
        }
    }

    void RoomSpawn()
    {
        roomType = Random.Range(0, 3);
        spawnTop = GameObject.Instantiate(spawnRoom[roomType], spawnTop.transform.position,
        spawnTop.transform.rotation).GetComponentInChildren<SpawnTopScript>().gameObject;
        spawnedRooms = spawnedRooms + 1;
    }
}
