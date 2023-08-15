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
    public float jumpChargeArrowScaleDiff;

    public Image jumpChargeScreenVFX;

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
        // NEED BETTER WAY TO DO THIS, EASING VARIABLES

        JumpingPlayerScript jumpingPlayer = player.GetComponent<JumpingPlayerScript>();
        if (jumpingPlayer.jumpCharge > 0 && jumpingPlayer.isGrounded)
        {
            jumpChargeValueStorage4FOV = jumpingPlayer.jumpCharge;
            jumpChargeValueStorage4ScreenVFX = jumpingPlayer.jumpCharge;
        }
        if (jumpingPlayer.jumpChargePrev == 0 && jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4FOV > 0)
            jumpChargeValueStorage4FOV -= jumpChargeValueStorage4FOVDecaySpeed * Time.deltaTime;
        if (jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4ScreenVFX > 0 && !jumpingPlayer.isGrounded)
            jumpChargeValueStorage4ScreenVFX -= jumpChargeValueStorage4ScreenVFXDecaySpeed * Time.deltaTime;


        float jumpChargeFOVValue = baseFOV + ((jumpChargeValueStorage4FOV) * jumpChargeFOVDiff);
        float jumpChargeScreenVFXValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeScreenVFXScaleDiff);
        float jumpChargeArrowScaleValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeArrowScaleDiff);


        jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);
        jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);
        jumpingPlayer.playerUI.jumpingVectorIndicator.transform.localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);



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
