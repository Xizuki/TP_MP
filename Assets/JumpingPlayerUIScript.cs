using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Nyp.Razor.Spectrum;

[RequireComponent(typeof(JumpingPlayerScript))]
public class JumpingPlayerUIScript : MonoBehaviour
{
    public float jumpingVectorAngleLimit;
    public float jumpVectorRotationSpeed;
    public JumpingPlayerScript player;
    public GameObject jumpingVectorIndicator;
    public ImageProgressBar jumpChargeArrow;
    public ImageProgressBar jumpChargeSlider;
    public GameObject jumpChargeSliderFill;
    public Transform playerHeadTransform;
    public Transform jumpingVectorIndicatorEndPoint;
    public float jumpingVectorEndPointYMaxDistance;
    public float playerHeadLookUpAngleLimit;
    public float playerJumpVectorIndicatorHardAngleLimit;
    private Outline outlineScript;

    public ParticleSystem[] interpolateParticle;
    //private ParticleSystem.MainModule interpolateps;
    //private ParticleSystem.MainModule interpolateps2;

    //public SpriteRenderer arrowSprite;
    public Color arrowStartingColor;
    public Color arrowEndColor;  

    public Color startingColor;
    public Color endColor;
    public Color interpolatedColor;
    public TextMeshPro chargeText;

    public Image sliderColor1;
    public Image sliderColor2;
    public ParticleSystem chargePulseVFX;

    public Vector3 faceForward = new Vector3(0, 0, 270);

    public Image normalShiba;
    public Image stunShiba;

    public LineRenderer lineRenderer;


    public ImageProgressBar[] arrows;
    public float enlargeArrowsScalar;
    public float vibrationScalar;
    public ParticleSystem[] arrowCellsChargedVFX;
    public AudioClip arrowCellsChargedSFX;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();
        outlineScript = GetComponentInChildren<Outline>();
        chargePulseVFX = GetComponentInChildren<ParticleSystem>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }
    public void Start()
    {
        jumpingVectorEndPointYMaxDistance = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y);
        //interpolateps = interpolateParticle[1].main;
        //interpolateps2 = interpolateParticle[2].main;

        
    }

    private void FixedUpdate()
    {
        //float cellMaxCharge = 0.33f;
        //float jumpChargeValue = player.jumpCharge;
        //print("jumpChargeValue = " + jumpChargeValue);
        for (int i = 0; i < arrows.Length; i++)
        {

            //if (jumpChargeValue < 0)
            //{
            //    arrows[i].value = 0;
            //    if (i > 0) { arrows[i].gameObject.SetActive(false); }
            //    continue;
            //}

            //arrows[i].gameObject.SetActive(true);

            //float dividedJumpCharge = cellMaxCharge;

            //jumpChargeValue -= cellMaxCharge;

            //if (jumpChargeValue < 0)
            //{
            //    dividedJumpCharge += jumpChargeValue;
            //}

            //dividedJumpCharge *=  arrows.Length;

            //arrows[i].value = dividedJumpCharge;

            //// << RUN VFXs on arrows




            //if (player.jumpCharge > 0 && player.isGrounded)
            //{
            //    jumpChargeValueStorage4FOV = player.jumpCharge;
            //    jumpChargeValueStorage4ScreenVFX = player.jumpCharge;
            //}
            //if (player.jumpChargePrev == 0 && player.jumpCharge == 0 && jumpChargeValueStorage4FOV > 0)
            //    jumpChargeValueStorage4FOV -= jumpChargeValueStorage4FOVDecaySpeed * Time.deltaTime;
            //if (player.jumpCharge == 0 && jumpChargeValueStorage4ScreenVFX > 0 && !player.isGrounded)
            //    jumpChargeValueStorage4ScreenVFX -= jumpChargeValueStorage4ScreenVFXDecaySpeed * Time.deltaTime;


            //float jumpChargeFOVValue = baseFOV + ((jumpChargeValueStorage4FOV) * jumpChargeFOVDiff);
            //float jumpChargeScreenVFXValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeScreenVFXScaleDiff);
            //float jumpChargeArrowScaleValue = (1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeArrowScaleDiff)) * baseArrowScale;

            //jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);

            //jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);

            //playerUI.arrows[0].GetComponentInChildren<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);
            //jumpChargeArrowScaleValue -= 0.33f;
            //playerUI.arrows[1].GetComponentInChildren<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);
            //jumpChargeArrowScaleValue -= 0.33f;
            //playerUI.arrows[2].GetComponentInChildren<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);

            //Camera.main.fieldOfView = jumpChargeFOVValue;




            // >>


        }

        //interpolateParticle[1].startColor = interpolatedColor;
        //interpolateParticle[2].startColor = interpolatedColor;
        //interpolateParticle[3].startColor = interpolatedColor;
        //interpolateParticle[4].startColor = interpolatedColor;
        //interpolateParticle[5].startColor = interpolatedColor;
        //interpolateParticle[6].startColor = interpolatedColor;
        jumpChargeSlider.value = player.jumpCharge;
        jumpChargeArrow.value = player.jumpCharge;
        var vfx = chargePulseVFX.main;
        vfx.startLifetime = 2+ (player.jumpCharge * 3);
        //vfx.duration =3f - (player.jumpCharge * 1.5f);
       
    }

    // Update is called once per frame
    void LateUpdate()
    {


        if (player.jumpCharge > 0)
            // Interpolate the color between startColor and endColor based on the interpolationValue
            //interpolatedColor = Color.Lerp(startingColor, endColor, player.jumpCharge);

        // Assign the interpolated color to the renderer component
        sliderColor1.color = interpolatedColor;
        sliderColor2.color = interpolatedColor;
        //player.lineRenderer.startColor = new Color(0.01f + (interpolatedColor.r) * 10, 0.01f + (interpolatedColor.g) * 10, 0.01f+(interpolatedColor.b) * 10, interpolatedColor.a);
        //player.lineRenderer.endColor = interpolatedColor;
        outlineScript.OutlineColor = interpolatedColor;

        //arrowSprite.color = Color.Lerp(arrowStartingColor, arrowEndColor, player.jumpCharge);

        if (player.isCharging == true)
        {
            playerHeadTransform.localEulerAngles = faceForward;
            //player.playerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);



            if (player.isCharging == true)
            {
                //Debug.Log("Testing Code");
                playerHeadTransform.localEulerAngles = faceForward;
                //player.playerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);


            }

            //Make player face camera
            //If want to make player facefront, determined by timer
            //If player is grounded
            //If player can rotate, this is meant to stop player from resetting when charging
            else if (player.faceFront == true && player.isGrounded == true && player.canRotate == true)
            {

                playerHeadTransform.localEulerAngles = new Vector3(0, 0, 0);
                player.jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            //Make player look at jump direction
            else if (player.faceFront == false && player.canRotate == true && player.isGrounded)
            {

                float currentEndPointYDistanceRatio = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y) / jumpingVectorEndPointYMaxDistance;
                playerHeadTransform.localEulerAngles = new Vector3(0, playerHeadTransform.localEulerAngles.y, -playerHeadLookUpAngleLimit * currentEndPointYDistanceRatio);
            }






            // Should be Moved to a method to be called by playerScript to stop unnessary calculations and effiency
            // But im lazy rn

            //if (!player.isGrounded)
            //{
            //    jumpChargeSlider.gameObject.SetActive(false);
            //}
            //else
            //{
            //    jumpChargeSlider.gameObject.SetActive(true);

            //    jumpChargeSlider.value = player.jumpCharge;
            //    jumpChargeSlider.maxValue = 1;

            //    if (jumpChargeSlider.value <= 0)
            //    {
            //        jumpChargeSliderFill.SetActive(false);
            //    }
            //    else
            //    {
            //        jumpChargeSliderFill.SetActive(true);
            //    }
            //}

        }


    }

   


}