//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class JumpingPlayerCameraScript : MonoBehaviour
//{
//    public GameObject player;
//    public float yOffset;
//    public float highestY;
//    public float platformHeightOffset = 1;

//    public Color screenVFXStartColor;
//    public Color screenVFXEndColor;
//    public float jumpChargeValueStorage4FOVDecaySpeed;
//    public float jumpChargeValueStorage4ScreenVFXDecaySpeed;
//    public float jumpChargeValueStorage4FOV;
//    public float jumpChargeValueStorage4ScreenVFX;
//    public float jumpChargeFOVDiff;
//    public float jumpChargeScreenVFXScaleDiff;

//    public Image jumpChargeScreenVFX;

//    // Start is called before the first frame update
//    void Start()
//    {
//        baseFOV = Camera.main.fieldOfView;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        CameraEnlargeOnCharge();

//        CameraPositioning();
//    }

//    private float baseFOV;

//    public void CameraEnlargeOnCharge()
//    {
//        // NEED BETTER WAY TO DO THIS, EASING VARIABLES

//        JumpingPlayerScript jumpingPlayer = player.GetComponent<JumpingPlayerScript>();
//        if (jumpingPlayer.jumpCharge > 0 && jumpingPlayer.isGrounded)
//        {
//            jumpChargeValueStorage4FOV = jumpingPlayer.jumpCharge;
//            jumpChargeValueStorage4ScreenVFX = jumpingPlayer.jumpCharge;
//        }
//        if (jumpingPlayer.jumpChargePrev == 0 && jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4FOV > 0)
//            jumpChargeValueStorage4FOV -= jumpChargeValueStorage4FOVDecaySpeed * Time.deltaTime;
//        if (jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4ScreenVFX > 0 && !jumpingPlayer.isGrounded)
//            jumpChargeValueStorage4ScreenVFX -= jumpChargeValueStorage4ScreenVFXDecaySpeed * Time.deltaTime;


//        float jumpChargeFOVValue = baseFOV + ((jumpChargeValueStorage4FOV) * jumpChargeFOVDiff);
//        float jumpChargeScreenVFXValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeScreenVFXScaleDiff);


//        jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);
//        jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);
//        jumpingPlayer.playerUI.jumpingVectorIndicator.transform.localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);



//        Camera.main.fieldOfView = jumpChargeFOVValue;
//    }
//    public void CameraPositioning()
//    {
//        float currentY = player.transform.position.y;

//        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

//        highestY = currentY;

//        transform.position = new Vector3(transform.position.x, highestY + yOffset, transform.position.z);
//    }
//}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPlayerCameraScript : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public JumpingPlayerUIScript playerUI;
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
    public float jumpChargeArrowPositionDiff;
    public float jumpChargeValueStorage4Arrow;



    public Image jumpChargeScreenVFX;

    // Start is called before the first frame update
    void Start()
    {
        jumpingPlayer = GameObject.FindObjectOfType<JumpingPlayerScript>();
        playerUI = jumpingPlayer.playerUI;

        baseFOV = Camera.main.fieldOfView;
        baseArrowScale = playerUI.arrows[0].GetComponentInChildren<RectTransform>().localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        CameraEnlargeOnCharge();

        CameraPositioning();
    }

    private float baseFOV;
    private float baseArrowScale;


    public bool[] arrowsCharged;

    public void CameraEnlargeOnCharge()
    {
        // NEED BETTER WAY TO DO THIS, EASING VARIABLES

        //JumpingPlayerScript jumpingPlayer = player.GetComponent<JumpingPlayerScript>();
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

        jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);
        jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);

        
        Camera.main.fieldOfView = jumpChargeFOVValue;




        float cellMaxCharge = 0.33f;
        float jumpChargeValue = jumpChargeValueStorage4ScreenVFX;
        print("jumpChargeValue = " + jumpChargeValue);




        for (int i = 0; i < playerUI.arrows.Length; i++)
        {

            if (jumpChargeValue < 0)
            {
                playerUI.arrows[i].value = 0;
                //if (i > 0) { playerUI.arrows[i].gameObject.SetActive(false); }
                continue;
            }

            //playerUI.arrows[i].gameObject.SetActive(true);

            float dividedJumpCharge = cellMaxCharge;

            jumpChargeValue -= cellMaxCharge;

            if (jumpChargeValue < 0)
            {
                dividedJumpCharge += jumpChargeValue;
            }

            dividedJumpCharge *= playerUI.arrows.Length;

            playerUI.arrows[i].value = dividedJumpCharge;

            // << RUN VFXs on arrows

            float jumpChargeArrowScaleValue = (1 + ((dividedJumpCharge) * jumpChargeArrowScaleDiff)) * baseArrowScale;

            playerUI.arrows[i].GetComponent<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);
            playerUI.arrows[i].fillImage.color = Color.Lerp(playerUI.startingColor, playerUI.endColor, dividedJumpCharge);


            // >> 
        }


    }
    public void CameraPositioning()
    {
        float currentY = jumpingPlayer.transform.position.y;

        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

        highestY = currentY;

        transform.position = new Vector3(transform.position.x, highestY + yOffset, transform.position.z);
    }
}
