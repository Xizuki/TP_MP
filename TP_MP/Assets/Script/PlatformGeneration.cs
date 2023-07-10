using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{

    [HideInInspector] public float groundHeight;
    public int maxPlatforms = 20;
    public GameObject platform;

    //We are spawning platforms to the right of our first platform.
    //The horizontalMin and horizontalMax are the min and max distance between each platforms to be spawned.  
    public float horizontalMin = -6.5f;
    public float horizontalMax = 10f;
    public float verticalMin = 4f;
    public float verticalMax = 15f;

    private Vector2 originPosition;

    public GameObject shibaKnight;
    public Vector3 heroPosition;
    public Vector3 randomPosition;
    private GameObject[] platformSpawn;
    void Start()
    {
        heroPosition = shibaKnight.transform.position; //receives Game Object var Position
        groundHeight = platform.GetComponent<SpriteRenderer>().bounds.size.y / 2; //takes platform var y position divided by 2
        Spawn(); //Call spawn function
    }
    void Update()
    {
        heroPosition = shibaKnight.transform.position; //takes Game object position
        if (heroPosition.y > (platformSpawn[maxPlatforms - 1].transform.position.y - groundHeight)) //If game object y position is more then the 2nd last platforms y position minus ground height var
        {
            originPosition = randomPosition; //randomise origin position
            Spawn(); //Call spawn function
        }
    }

    void Spawn() // Spawn function
    {
        platformSpawn = new GameObject[maxPlatforms]; // take platform Object to be platform spawn

        for (int i = 0; i < maxPlatforms; i++) //for loop 
        {
            //we are creating a new position of the next platform value
            randomPosition = new Vector3(originPosition.x + groundHeight, originPosition.y) + new Vector3(Random.Range(horizontalMin, horizontalMax),
    Random.Range(verticalMin, verticalMax));
            //Instantiate(platform, randomPosition, Quaternion.identity);
            platformSpawn[i] = Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}
