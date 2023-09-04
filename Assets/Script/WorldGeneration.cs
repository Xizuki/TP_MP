using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public List<GameObject> Rooms = new List<GameObject>();

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
        Rooms.Add(GameObject.Instantiate(spawnRoom[roomType], spawnTop.transform.position, spawnTop.transform.rotation));
        spawnTop = Rooms[Rooms.Count-1].GetComponentInChildren<SpawnTopScript>().gameObject;
        roomType += 1;

        if (roomType >= 9)
        {        
            Debug.Log(roomType);

            roomType = 0;
            Debug.Log("hit");
        }
        spawnedRooms = spawnedRooms + 1;

        if(Rooms.Count > 3)
        {
            Destroy(Rooms[0]);
            Rooms.RemoveAt(0);
        }
    }
}
