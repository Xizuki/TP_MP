using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Update is called once per frame
    void LateUpdate()
    {
        // Player Head Looking at jump direection
        float currentEndPointYDistanceRatio = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y) / jumpingVectorEndPointYMaxDistance;
        playerHeadTransform.localEulerAngles = new Vector3(0, 0, -playerHeadLookUpAngleLimit* currentEndPointYDistanceRatio);


        // Interpolate the color between startColor and endColor based on the interpolationValue
        interpolatedColor = Color.Lerp(startingColor, endColor, player.jumpCharge);
        // Assign the interpolated color to the renderer component
        sliderColor1.color = interpolatedColor;
        sliderColor2.color = interpolatedColor;

        print("sliderColor1.color == interpolatedColor " + (sliderColor1.color == interpolatedColor));

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
}
