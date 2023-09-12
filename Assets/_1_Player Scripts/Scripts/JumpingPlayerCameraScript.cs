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




using Nyp.Razor.Spectrum;
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
        jumpChargeScreenVFX = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>().jumpChargeScreenVFX;

        jumpingPlayer = GameObject.FindObjectOfType<JumpingPlayerScript>();
        playerUI = jumpingPlayer.playerUI;

        baseFOV = Camera.main.fieldOfView;
        baseArrowScale = playerUI.arrows[0].GetComponentInChildren<RectTransform>().localScale.x;

        arrowsCharged = new bool[playerUI.arrows.Length];
        arrowEndPoints = new Transform[playerUI.arrows.Length];

        for(int i = 0; i < playerUI.arrows.Length; i++) 
        {
            arrowEndPoints[i] = playerUI.arrows[i].GetComponentInChildren<ArrowEndPoint>().transform;
        }
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
    public Transform[] arrowEndPoints;
    bool arrowScalingStarted;
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
        GameObject.FindGameObjectWithTag("OverlayCam").GetComponent<Camera>().fieldOfView = jumpChargeFOVValue;



        bool arrowPulsing = false;
        float cellMaxCharge = 0.33f;
        float jumpChargeValue = jumpChargeValueStorage4ScreenVFX;


        //playerUI.interpolatedColor = Color.Lerp(playerUI.startingColor, playerUI.endColor, jumpChargeValueStorage4ScreenVFX);
        Color interpolatedColor = playerUI.SetColor(jumpChargeValueStorage4ScreenVFX);


        if (jumpChargeValue <= 0.995f)
        {
            //playerUI.chargePulseVFX.gameObject.SetActive(false);
            playerUI.chargePulseVFX.Stop();
            arrowPulsing = false;
        }
        else
        {
            arrowPulsing = true;
            //playerUI.chargePulseVFX.gameObject.SetActive(true);
            playerUI.chargePulseVFX.Play();

        }




        for (int i = 0; i < playerUI.arrows.Length; i++)
        {
            playerUI.arrows[i].fillImage.color = playerUI.interpolatedColor;
            if(i > 0)
                playerUI.arrows[i].transform.position = arrowEndPoints[i - 1].position;

            if (jumpChargeValue <= 0)
            {
                playerUI.arrows[i].value = 0;
                //if (i > 0) { playerUI.arrows[i].gameObject.SetActive(false); }
                continue;
            }

            //playerUI.arrows[i].gameObject.SetActive(true);

            if (jumpChargeValue > cellMaxCharge)
            {
                
                if (!arrowsCharged[i])
                {

                    arrowsCharged[i] = true;
                    playerUI.arrowCellsChargedVFX[i].gameObject.SetActive(true);
                    playerUI.arrowCellsChargedVFX[i].Play();
                    playerUI.arrowCellsChargedVFX[i].startColor = playerUI.interpolatedColor;

                    //playerUI.arrowCellsChargedVFX[i].startColor = Color.green;

                    //playerUI.arrowCellsChargedVFX[i].startRotation = playerUI.jumpingVectorIndicator.transform.rotation.eulerAngles.z / (180.0f / Mathf.PI);

                }
            }
 

            float dividedJumpCharge = cellMaxCharge;

            jumpChargeValue -= cellMaxCharge;


            
            if (jumpChargeValue <= 0)
            {
                dividedJumpCharge += jumpChargeValue;

                if (arrowsCharged[i])
                    arrowsCharged[i] = false;
            }

            dividedJumpCharge *= playerUI.arrows.Length;

            playerUI.arrows[i].value = dividedJumpCharge;

            // << RUN VFXs on arrows

            float jumpChargeArrowScaleValue = (1 + ((dividedJumpCharge) * jumpChargeArrowScaleDiff)) * baseArrowScale;

            playerUI.arrows[i].GetComponent<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);

            //playerUI.arrows[i].fillImage.color = Color.Lerp(playerUI.startingColor, playerUI.endColor, dividedJumpCharge);



            // >> 
        }


        float arrowScale = (1 + jumpChargeArrowScaleDiff)*(baseArrowScale);


        if (arrowPulsing)
        {
            if (!arrowScalingStarted)
            {
                foreach (ImageProgressBar arrow in playerUI.arrows)
                {
                    arrow.GetComponent<PulsingScaleScript>().timeElapsed = 0;
                }
                    
                arrowScalingStarted = true;
            }
            foreach (ImageProgressBar arrow in playerUI.arrows)
            {
                arrow.GetComponent<PulsingScaleScript>().initialScale = new Vector3(arrowScale, arrowScale, arrowScale);
                
               

                arrow.GetComponent<PulsingScaleScript>().hasStarted = true;
                arrow.GetComponent<PulsingScaleScript>().stoppingStarted = false;

            }

        }
        else
        {
            foreach (ImageProgressBar arrow in playerUI.arrows)
            {
                if (jumpingPlayer.jumpCharge > 0)
                {
                    arrow.GetComponent<PulsingScaleScript>().initialScale = new Vector3(arrowScale, arrowScale, arrowScale); ;
                    arrow.GetComponent<PulsingScaleScript>().stoppingStarted = true;
                }
                else
                {
                    arrow.GetComponent<PulsingScaleScript>().forceStop = true;
                    arrow.GetComponent<RectTransform>().localScale = new Vector3(baseArrowScale, baseArrowScale, baseArrowScale);
                }
                arrowScalingStarted = false;
            }
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
