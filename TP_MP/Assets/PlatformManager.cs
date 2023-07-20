using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XizukiMethods.GameObjects;

public class PlatformManager : MonoBehaviour
{
    public Chicken chicken;
    public JumpingPlayerScript player;
    public List<PlatformScript> platforms;
    public static PlatformManager instance;
    public PlatformScript lastLandedPlatform;

    // Very half ass way of doing it, should be done in code if have time
    public Transform platformDissappearingPoint;

    private void Awake()
    {
        XizukiMethods.GameObjects.Xi_Helper_GameObjects.MonoInitialization<PlatformManager>(ref instance, this);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetLastLandedPlatform(PlatformScript collidedPlatform)
    {
        if (collidedPlatform.transform.position.y < lastLandedPlatform.transform.position.y) { return; }

        lastLandedPlatform = collidedPlatform;

        chicken.startingPlatform = collidedPlatform.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        // Only Run this Script when new platforms are generated for optimization
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject GO in GOs)
        {
            platforms.Add(GO.GetComponent<PlatformScript>());
        }

        List<PlatformScript> platformsToRemove = new List<PlatformScript>();

        foreach (PlatformScript platform in platforms)
        {
            if (platform == lastLandedPlatform) { continue; }

            if (platform.transform.position.y >= lastLandedPlatform.transform.position.y) { continue; }

            if (platform.transform.position.y < platformDissappearingPoint.transform.position.y)
            {
                Destroy(platform.gameObject);
            }
        }

        foreach (PlatformScript platform in platformsToRemove)
        {
            platforms.Remove(platform);
        }

        //very inefficient, the fix in this should be done with the one on top
        platforms.Clear();

        if (player.transform.position.y < platformDissappearingPoint.transform.position.y - 1f)
        {
            chicken.playerDowned = true;
            chicken.AbovePlatformCheck();
        }
    }
}