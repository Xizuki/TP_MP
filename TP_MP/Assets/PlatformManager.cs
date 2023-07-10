using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    public PlatformScript lastLandedPlatform;

    private void Awake()
    {
        XizukiMethods.GameObjects.Xi_Helper_GameObjects.MonoInitialization<PlatformManager>(ref instance, this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetLastLandedPlatform(PlatformScript collidedPlatform)
    {
        if(collidedPlatform.transform.position.y < lastLandedPlatform.transform.position.y) { return; }

        lastLandedPlatform = collidedPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
