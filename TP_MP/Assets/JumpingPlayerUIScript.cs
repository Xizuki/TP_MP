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
    public GameObject jumpChargerSliderFill;
    public Transform playerHeadTransform;
    public Transform jumpingVectorIndicatorEndPoint;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();
    }
    public void Start()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        playerHeadTransform.up = -(jumpingVectorIndicatorEndPoint.position - playerHeadTransform.position);

        float zValue = playerHeadTransform.localEulerAngles.z;
        //if(zValue < 0) { zValue *= -1; }

        playerHeadTransform.localEulerAngles = new Vector3(0, -jumpingVectorIndicator.transform.eulerAngles.z, 0);

        // Should be Moved to a method to be called by jumpingPlayerScript to stop unnessary calculations and effiency
        // But im lazy rn
        jumpChargeSlider.value = player.jumpCharge;
        jumpChargeSlider.maxValue = 1;

        if(jumpChargeSlider.value <= 0)
        {
            jumpChargerSliderFill.SetActive(false);
        }
        else
        {
            jumpChargerSliderFill.SetActive(true);
        }
    }
}
