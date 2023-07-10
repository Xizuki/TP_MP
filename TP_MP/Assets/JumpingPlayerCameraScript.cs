using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerCameraScript : MonoBehaviour
{
    public GameObject player;
    public float yOffset;
    public float highestY;
    public float platformHeightOffset = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentY = player.transform.position.y;

        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

        highestY = currentY;

        transform.position = new Vector3( transform.position.x, highestY + yOffset, transform.position.z);
    }
}
