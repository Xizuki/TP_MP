using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    [SerializeField]
    public WorldChunkDetail chunkDetails;

    public int unitXCount;
    public int unitYCount;


    public ComputeShader computeShader;
    public RenderTexture resultTexture;

    void Start()
    {
      
    }

    void Update()
    {
    }


    public void InitializeChunk()
    {

    }

    private void RandomGenerateUnits()
    {
        
    }




}

[System.Serializable]
public class WorldChunkDetail
{
    public int chunkId;
    public bool hasInitialized;
    public int xPos;
    public int yPos;

}