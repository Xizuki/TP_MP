using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerationRandom : MonoBehaviour
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
        Rooms.Add(GameObject.Instantiate(spawnRoom[Random.Range(0, spawnRoom.Count - 1)], spawnTop.transform.position, spawnTop.transform.rotation));

        spawnTop = Rooms[Rooms.Count-1].GetComponentInChildren<SpawnTopScript>().gameObject;

        if (Rooms[Rooms.Count - 1].GetComponent<XI_TextureParent>()) 
        {
            Rooms[Rooms.Count - 1].GetComponent<XI_TextureParent>().GenerateAllMaterialInstance();
        }

        if (Rooms.Count > 3)
        {
            Destroy(Rooms[0]);
            Rooms.RemoveAt(0);
        }
    }
}
