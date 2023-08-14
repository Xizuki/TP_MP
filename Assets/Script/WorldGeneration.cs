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
    private int randomRangeIndex = 0;

    private int[][] randomRanges = new int[][]
    {
        new int[] { 0, 3 },
        new int[] { 4, 6 },
        new int[] { 7, 9 }
    };


    // Start is called before the first frame update
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

        /*
        if (spawnedRooms > 0 && spawnedRooms % 3 == 0)
        {
            randomRangeIndex = (randomRangeIndex + 1) % randomRanges.Length;
        }

        int[] currentRange = randomRanges[randomRangeIndex];
        int randomValue = currentRange[Random.Range(0, currentRange.Length)];

        Debug.Log("Random Value: " + randomValue);*/
    }
}
