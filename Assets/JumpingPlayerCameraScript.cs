using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerCameraScript : MonoBehaviour
{
    public GameObject player;
    public float yOffset;
    public float highestY;
    public float platformHeightOffset = 1;

   
    public float jumpChargeValueStorageDecaySpeed;
    public float jumpChargeValueStorage;
    public float jumpChargeFOVDiff;
    // Start is called before the first frame update
    void Start()
    {
        baseFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        CameraEnlargeOnCharge();

        CameraPositioning();
    }

    private float baseFOV;

    public void CameraEnlargeOnCharge()
    {
        JumpingPlayerScript jumpingPlayer = player.GetComponent<JumpingPlayerScript>();
        if (jumpingPlayer.jumpCharge > 0 && jumpingPlayer.isGrounded && jumpingPlayer.isCharging)
            jumpChargeValueStorage = jumpingPlayer.jumpCharge;
        else if(jumpingPlayer.jumpChargePrev == 0 && jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage >0 && !jumpingPlayer.isCharging)
            jumpChargeValueStorage -= jumpChargeValueStorageDecaySpeed * Time.deltaTime;

        Camera.main.fieldOfView = baseFOV + ((jumpChargeValueStorage) * jumpChargeFOVDiff);
    }
    public void CameraPositioning()
    {
        float currentY = player.transform.position.y;

        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

        highestY = currentY;

        transform.position = new Vector3(transform.position.x, highestY + yOffset, transform.position.z);
    }
}
