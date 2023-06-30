using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenTest : MonoBehaviour
{
    public GameObject player;
    
    [SerializeField]
    public WorldChunksArray worldChunksArray;

    public GameObject creationPlane;
    public int currentWorldChunk_x;
    public int currentWorldChunk_y;
    public WorldChunk currentWorldChunk;
    public WorldChunk worldChunkPrefab;

    int addedPositiveX;
    int addedPositiveY;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        currentWorldChunk_x = 0;
        currentWorldChunk_y = 0;
    }

 

   

    private void GenerateWorldUnit()
    {

    }

    private void InitializeWorldUnits()
    {

    }

    private void InitializeWorldBlocks()
    {

    }

    private void InitializeWorldProps()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckCurrentWorldChunk();
    }

    private void CheckCurrentWorldChunk()
    {
        RaycastHit[] hits;

        hits = Physics.RaycastAll(player.transform.position, Vector3.down, Mathf.Infinity);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.GetComponent<WorldChunk>() == null) { continue; }

            if(currentWorldChunk != hits[i].collider.gameObject.GetComponent<WorldChunk>()) 
            { 
                CheckAdjacentWorldChunks(); 
            }
            
            currentWorldChunk = hits[i].collider.gameObject.GetComponent<WorldChunk>();
            currentWorldChunk_x = currentWorldChunk.chunkDetails.xPos;
            currentWorldChunk_y = currentWorldChunk.chunkDetails.yPos;
        }
    }

    private void CheckAdjacentWorldChunks()
    {
        int x = currentWorldChunk_x;
        int y = currentWorldChunk_y;

        for (int xOffset = -1; xOffset < 1; xOffset++)
        {
            for (int yOffset = -1; yOffset < 1; yOffset++)
            {
                if (xOffset == 0 && yOffset == 0) { continue; }

                int offSettedX = x + xOffset;
                int offSettedY = y + yOffset; 

                if (offSettedX < 0 || offSettedY < 0)
                {
                    ExtendWorldChunkArray(xOffset, yOffset);
                }
                else if (offSettedX >= worldChunksArray.worldChunksX.Count 
                || offSettedY >= worldChunksArray.worldChunksX[0].worldChunksY.Count)
                {
                    ExtendWorldChunkArray(xOffset, yOffset);
                }


                GenerateWorldChunk();
            }
        }
    }
    private void ExtendWorldChunkArray(int x, int y)
    {
        bool insertedNegativeX = false;
        bool insertedNegativeY = false;

        if (x > 0)
        {
            worldChunksArray.worldChunksX.Add(new WorldChunksArrayX());
        }
        else if(x < 0)
        {
            worldChunksArray.worldChunksX.Insert(0,new WorldChunksArrayX());
            insertedNegativeX = true;
        }

        if (y > 0)
        {
            foreach(WorldChunksArrayX worldChunkX in worldChunksArray.worldChunksX)
            {
                worldChunkX.worldChunksY.Add(null);
            }
        }
        else if (y < 0)
        {
            foreach (WorldChunksArrayX worldChunkX in worldChunksArray.worldChunksX)
            {
                worldChunkX.worldChunksY.Insert(0,null);
                insertedNegativeY = true;
            }
        }

        WorldChunkArrayNegativeIndexAdjustments(insertedNegativeX, insertedNegativeY);
    }


    private void WorldChunkArrayNegativeIndexAdjustments(bool insertedNegativeX, bool insertedNegativeY)
    {
        int insertedX = 0;
        int insertedY = 0;

        if (insertedNegativeX)
            insertedX = 1;
        if (insertedNegativeY)
            insertedY = 1;

        for (int x = insertedX; x < worldChunksArray.worldChunksX.Count; x++)
        {
            for (int y = insertedY; y < worldChunksArray.worldChunksX[x].worldChunksY.Count; y++)
            {
                worldChunksArray.worldChunksX[x].worldChunksY[y].chunkDetails.xPos += insertedX;
                worldChunksArray.worldChunksX[x].worldChunksY[y].chunkDetails.yPos += insertedY;
            }
        }
    }


    private void GenerateWorldChunk()
    {

    }
    private void GenerateWorldChunk(int x, int y)
    {
        GameObject GO = GameObject.Instantiate(worldChunkPrefab).gameObject;
        
        // Will Have bugs due to negative chunks that get pushed up to index 0, pushing everything else 1 unit up.
        Vector3 originPos = worldChunksArray.worldChunksX[0].worldChunksY[0].transform.position;
        float xPosDiff = worldChunksArray.worldChunksX.Count * worldChunkPrefab.transform.localScale.x;
        float yPosDiff = worldChunksArray.worldChunksX[0].worldChunksY.Count * worldChunkPrefab.transform.localScale.z;
        
        GO.transform.position = originPos+new Vector3(xPosDiff,0,yPosDiff);    
    }
}



[System.Serializable]
public struct WorldChunksArray
{
    public List<WorldChunksArrayX> worldChunksX;
}
[System.Serializable]
public struct WorldChunksArrayX
{
    public List<WorldChunk> worldChunksY;
}



[System.Serializable]
public struct WorldUnitsArray
{
    public List<WorldUnit> worldUnits_x;
    public List<WorldUnit> worldUnits_y;
}








/*
public class WorldChunk
{
    public float relativeSize;
    public int chunkTypeIndex;
    public int chunkXMin;
    public int chunkXMax;
    public int chunkYMin;
    public int chunkYMax;
}

public class WorldChunksInterconnect 
{
    public float globalGradient;
    public Vector2 negativeGradient;
    public Vector2 psoitiveGradient;
}

public class WorldChunkLandmarks
{
    
}

public class WorldChunkPiece
{
    public int xPos;
    public int yPos;
    public int xSize;
    public int ySize;
}
*/