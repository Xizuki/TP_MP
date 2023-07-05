using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AreaType
{
    Basic
}

public class WorldGen_JumpingGame : MonoBehaviour
{
    public AreaType areaType;

    public bool platformTypeIsScalar;
    
    public PlatformScript startingPlatform;
    public PlatformScript voxelPlatformPrefab;
    public PlatformScript scalarPlatformPrefab;

    public float platformMinYDiff;
    public float platformMaxYDiff;

    public float platformMinXDiff;
    public float platformMaxXDiff;

    public float platformMinWidth;
    public float platformMaxWidth;

    public float platformMinTotalDistance;

    public PlatformScript prevPlatform;


    public void Awake()
    {
        if (platformTypeIsScalar)
            ScalarPlatformGeneration();
        else
            VoxelPlatformGeneration();  
    }

    private void ScalarPlatformGeneration()
    {
        float newPlatformMinY = prevPlatform.transform.position.y;
        float newPlatformMaxY = prevPlatform.transform.position.y + platformMaxYDiff;
        float newPlatformY = Random.Range(newPlatformMinY, newPlatformMaxY);

        float newPlatformMinX = prevPlatform.transform.position.x;
        float newPlatformMaxX = prevPlatform.transform.position.x + platformMaxXDiff;
        float newPlatformX = Random.Range(newPlatformMinY, newPlatformMaxY);


        float newPlatformWidth = Random.Range(platformMinWidth, platformMaxWidth);

    }

    private void VoxelPlatformGeneration()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
