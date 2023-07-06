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
        Vector3 direction = jumpingVectorIndicatorEndPoint.position - playerHeadTransform.transform.position;

        Quaternion newRot = playerHeadTransform.rotation;
        newRot.SetLookRotation(jumpingVectorIndicatorEndPoint.position, playerHeadTransform.forward);
        playerHeadTransform.rotation = newRot;
        playerHeadTransform.up = -playerHeadTransform.forward;
        //playerHeadTransform.eulerAngles = new Vector3(playerHeadTransform.eulerAngles.x, playerHeadTransform.eulerAngles.z, playerHeadTransform.eulerAngles.y);
        //playerHeadTransform.up = playerHeadTransform.forward;
        //playerHeadTransform.LookAt(jumpingVectorIndicatorEndPoint.position);

        //playerHeadTransform.up = -playerHeadTransform.forward;

        /*
        float zvalue = playerHeadTransform.localEulerAngles.z;
        float xvalue = 0;

        if(zvalue <180)
        {
            //xvalue = 180;
            playerHeadTransform.up = -playerHeadTransform.up;
            zvalue = playerHeadTransform.localEulerAngles.z-180f;

            print("REVERSE");
            print("REVERSE");
        }

        playerHeadTransform.localEulerAngles = new Vector3(xvalue,playerHeadTransform.localEulerAngles.y, zvalue);


        print(playerHeadTransform.eulerAngles);
        */

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
