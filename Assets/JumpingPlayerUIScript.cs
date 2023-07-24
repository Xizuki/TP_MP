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

    public Color startingColor;
    public Color endColor;
    public Color interpolatedColor;
    public TextMeshPro chargeText;
    float charge, maxCharge = 100;

    public Image chargeBar;
    public Image sliderColor1;
    public Image sliderColor2;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();

    }
    public void Start()
    {
        jumpingVectorEndPointYMaxDistance = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y);

    }

    private void Update()
    {
        if (charge > maxCharge) charge = maxCharge;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //Make player face camera
        //If want to make player facefront, determined by timer
        //If player is grounded
        //If player can rotate, this is meant to stop player from resetting when charging
        if (player.faceFront == true && player.isGrounded == true && player.canRotate == true)
        {

            playerHeadTransform.localEulerAngles = new Vector3(0, 0, 0);
            player.jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        //Make player look at jump direction
        else if (player.faceFront == false && player.canRotate == true && player.isGrounded)
        {

            float currentEndPointYDistanceRatio = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y) / jumpingVectorEndPointYMaxDistance;
            playerHeadTransform.localEulerAngles = new Vector3(0, 0, -playerHeadLookUpAngleLimit * currentEndPointYDistanceRatio);
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
