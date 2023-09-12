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
        {
            ScalarPlatformGeneration();

            for (int i = 0; i < 50; i++)
            {

                //ScalarPlatformGeneration();

            }
        }
        else
            VoxelPlatformGeneration();  
    }

    private void ScalarPlatformGeneration()
    {
        float newPlatformMinY = prevPlatform.transform.position.y;
        float newPlatformMaxY = prevPlatform.transform.position.y + platformMaxYDiff;
        float newPlatformY = Random.Range(newPlatformMinY, newPlatformMaxY);

        // Added to make sure platform is not directly above the other
        /// BUG >>>>>>  Will still cause bugs as it does not take into account length of platform
        int xNegative = Random.Range(0, 1);
        if (xNegative == 0) { xNegative--; }

        /// BUG >>>>>> Will Have bug as it does not take into account length of platform
        float newPlatformMinX = prevPlatform.transform.position.x;
        float newPlatformMaxX = prevPlatform.transform.position.x + platformMaxXDiff;
        float newPlatformX = Random.Range(newPlatformMinX*xNegative, newPlatformMaxX*xNegative);


        float newPlatformWidth = Random.Range(platformMinWidth, platformMaxWidth);



        GameObject GO = GameObject.Instantiate(scalarPlatformPrefab.gameObject, transform);
        GO.transform.position = new Vector3(newPlatformX, newPlatformY, 0);

        prevPlatform = GO.GetComponent<PlatformScript>();
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
