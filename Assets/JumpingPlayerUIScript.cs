using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(JumpingPlayerScript))]
public class JumpingPlayerUIScript : MonoBehaviour
{
    public float jumpingVectorAngleLimit;
    public float jumpVectorRotationSpeed;
    public JumpingPlayerScript player;
    public GameObject jumpingVectorIndicator;
    public Slider jumpChargeSlider;
    public GameObject jumpChargeSliderFill;
    public Transform playerHeadTransform;
    public Transform jumpingVectorIndicatorEndPoint;
    public float jumpingVectorEndPointYMaxDistance;
    public float playerHeadLookUpAngleLimit;
    public float playerJumpVectorIndicatorHardAngleLimit;

    public ParticleSystem[] interpolateParticle;
    //private ParticleSystem.MainModule interpolateps;
    //private ParticleSystem.MainModule interpolateps2;


    public Color startingColor;
    public Color endColor;
    public Color interpolatedColor;
    public TextMeshPro chargeText;
    float charge, maxCharge = 100;

    public Image chargeBar;
    public Image sliderColor1;
    public Image sliderColor2;

    public Vector3 faceForward = new(0, 0, 270);

    public Vector3 faceForward = new Vector3(0, 0, 270);

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();

    }
    public void Start()
    {
        jumpingVectorEndPointYMaxDistance = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y);
        //interpolateps = interpolateParticle[1].main;
        //interpolateps2 = interpolateParticle[2].main;


    }

    private void Update()
    {
        if (charge > maxCharge) charge = maxCharge;
        interpolateParticle[1].startColor = interpolatedColor;
        interpolateParticle[2].startColor = interpolatedColor;
        interpolateParticle[3].startColor = interpolatedColor;
        interpolateParticle[4].startColor = interpolatedColor;
        interpolateParticle[5].startColor = interpolatedColor;
        interpolateParticle[6].startColor = interpolatedColor;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (player.isCharging == true)
        {
            playerHeadTransform.localEulerAngles = faceForward;
            //player.jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);


      
        if (player.isCharging == true)
        {
            Debug.Log("Testing Code");
                playerHeadTransform.localEulerAngles = faceForward ;
            //player.jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);
            

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




        // Interpolate the color between startColor and endColor based on the interpolationValue
        interpolatedColor = Color.Lerp(startingColor, endColor, player.jumpCharge);
        // Assign the interpolated color to the renderer component
        sliderColor1.color = interpolatedColor;
        sliderColor2.color = interpolatedColor;

        // Should be Moved to a method to be called by jumpingPlayerScript to stop unnessary calculations and effiency
        // But im lazy rn
        
        if (!player.isGrounded)
        {
            jumpChargeSlider.gameObject.SetActive(false);
        }
        else
        {
            jumpChargeSlider.gameObject.SetActive(true);

            jumpChargeSlider.value = player.jumpCharge;
            jumpChargeSlider.maxValue = 1;

            if (jumpChargeSlider.value <= 0)
            {
                jumpChargeSliderFill.SetActive(false);
            }
            else
            {
                jumpChargeSliderFill.SetActive(true);
            }
        }
    }

    void ChargeBarFill()
    {
        chargeBar.fillAmount = charge / maxCharge;
    }
}
