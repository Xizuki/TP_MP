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
        GameObject GO = GameObject.Instantiate(spawnRoom[Random.Range(0, spawnRoom.Count)], spawnTop.transform.position,
        spawnTop.transform.rotation);

        spawnTop = GO.GetComponentInChildren<SpawnTopScript>().gameObject;

        if(GO.GetComponent<XI_TextureParent>()) 
        {
            GO.GetComponent<XI_TextureParent>().GenerateAllMaterialInstance();
        }
    }
}
