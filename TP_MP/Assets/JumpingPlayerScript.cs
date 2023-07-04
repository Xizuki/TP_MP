using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(JumpingPlayerUIScript))]
public class JumpingPlayerScript : MonoBehaviour
{
    public GameObject jumpingPlayerChildrenModel;
    public ControllerInput inputs;
    public JumpingPlayerUIScript playerUI;
    public Rigidbody rb;

    public float jumpCharge;
    public float jumpChargeSpeedCurrent;
    public float jumpChargeSpeedMax;
    public Vector2 jumpAngleVector;
    public float rbJumpStrength;

    public bool isGrounded;
    public bool isFalling;
    public Transform feetPos;

    public void Awake()
    {
        inputs = new ControllerInput();
        rb = GetComponent<Rigidbody>();
        playerUI = GetComponent<JumpingPlayerUIScript>();

        inputs.GameActions.Enable();

        inputs.GameActions.Jump.performed += a => Jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float inputValue;
    public float scalar;
    // Update is called once per frame
    void Update()
    {
        Inputs();

        jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0,-playerUI.jumpingVectorIndicator.transform.eulerAngles.z,0);


        if(rb.velocity.y < 4) { isFalling = true; }
        else { isFalling = false; }

        if (isFalling)
            rb.AddForce(new Vector3(0, -8, 0));



        

        float transformedValue = TransformValue(inputValue, scalar);

        Debug.Log("Transformed Value: " + transformedValue);

    }

    float TransformValue(float value, float scalar)
    {
        // Convert value to a non-linear scale
        float transformedValue = 0;

        for (int i = 0; i < inputValue;i++)
        {
            print(" i " + i + " = " + scalar * ((scalar * 50) / (50 + i)));
            transformedValue += scalar * (((scalar * 50) / (50 + i)));
        }

        return transformedValue;

    }

    private void Inputs()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
        }
        if(jumpCharge > 1)
        {
            jumpCharge = 1;
        }

        float angle = playerUI.jumpingVectorIndicator.transform.eulerAngles.z;
        float negative = angle >= 180 ? -1 : 1;
        angle = angle >= 180 ? 180 - (angle % 180) : angle;

        if (angle > playerUI.jumpingVectorAngleLimit + Time.deltaTime)
        {
            playerUI.jumpingVectorIndicator.transform.localEulerAngles = new Vector3(0, 0, playerUI.jumpingVectorAngleLimit * negative);
            return;
        }

        if (inputs.GameActions.MoveJumpVectorNegative.IsPressed())
            MoveJumpVectorNegative();
        if (inputs.GameActions.MoveJumpVectorPositive.IsPressed())
            MoveJumpVectorPositive();
    }

    private void MoveJumpVectorNegative()
    {
        playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, -1) * Time.deltaTime * playerUI.jumpVectorRotationSpeed;
    }
    private void MoveJumpVectorPositive()
    {
        playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * playerUI.jumpVectorRotationSpeed;
    }
    private void Jump()
    {
        if (!isGrounded || jumpCharge <=0) { return; }
        //float forceCalcs = TransformValue(rbJumpStrength * jumpCharge, scalar);
        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength * jumpCharge, ForceMode.Impulse);
        jumpCharge = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Very Simple, could maybe have bugs
        if (collision.contacts[0].point.y <= feetPos.position.y)
        {
            isGrounded = true;
        }
    }

}
