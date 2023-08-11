using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPlayerCameraScript : MonoBehaviour
{
    public GameObject player;
    public float yOffset;
    public float highestY;
    public float platformHeightOffset = 1;

    public Color screenVFXStartColor;
    public Color screenVFXEndColor;
    public float jumpChargeValueStorage4FOVDecaySpeed;
    public float jumpChargeValueStorage4ScreenVFXDecaySpeed;
    public float jumpChargeValueStorage4FOV;
    public float jumpChargeValueStorage4ScreenVFX;
    public float jumpChargeFOVDiff;
    public float jumpChargeScreenVFXScaleDiff;

    public Image jumpChargeScreenVFX;

    public Camera overlayCamera;

    // Start is called before the first frame update
    void Start()
    {
        baseFOV = Camera.main.fieldOfView;

    }

    // Update is called once per frame
    void Update()
    {
        print(XizukiMethods.Data.Xi_Helper_Data.GetVariableName(() => baseFOV));
        print(XizukiMethods.Data.Xi_Helper_Data.GetDynamicVariableName(() => baseFOV));
        //print(XizukiMethods.Math.Xi_Helper_Math.CalculateFromString("cos(15)"));
        CameraEnlargeOnCharge();

        CameraPositioning();

        overlayCamera.fieldOfView = Camera.main.fieldOfView;
    }

    private float baseFOV;

    public void CameraEnlargeOnCharge()
    {

        // NEED BETTER WAY TO DO THIS, EASING VARIABLES

        JumpingPlayerScript jumpingPlayer = player.GetComponent<JumpingPlayerScript>();
        if (jumpingPlayer.jumpCharge > 0 && jumpingPlayer.isGrounded)
        {
            jumpChargeValueStorage4FOV = jumpingPlayer.jumpCharge;
            jumpChargeValueStorage4ScreenVFX = jumpingPlayer.jumpCharge;
        }
        if (jumpingPlayer.jumpChargePrev == 0 && jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4FOV > 0 )
            jumpChargeValueStorage4FOV -= jumpChargeValueStorage4FOVDecaySpeed * Time.deltaTime;
        if (jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4ScreenVFX > 0 && !jumpingPlayer.isGrounded)
            jumpChargeValueStorage4ScreenVFX -= jumpChargeValueStorage4ScreenVFXDecaySpeed * Time.deltaTime;


        float jumpChargeFOVValue = baseFOV + ((jumpChargeValueStorage4FOV) * jumpChargeFOVDiff);
        float jumpChargeScreenVFXValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeScreenVFXScaleDiff);

        jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);
        jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);
        jumpingPlayer.playerUI.jumpingVectorIndicator.transform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);

        Camera.main.fieldOfView = jumpChargeFOVValue;
    }
    public void CameraPositioning()
    {
        float currentY = player.transform.position.y;

        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

        highestY = currentY;

        transform.position = new Vector3(transform.position.x, highestY + yOffset, transform.position.z);
    }
}
