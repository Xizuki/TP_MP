using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(JumpingPlayerUIScript))]
public class JumpingPlayerScript : MonoBehaviour
{
    public ControllerInput inputs;
    public JumpingPlayerUIScript playerUI;
    public Rigidbody rb;

    public float jumpCharge;
    public float jumpChargeMax;
    public float jumpChargeSpeed;
    public Vector2 jumpAngleVector;
    public float rbJumpStrength;

    public bool isGrounded;

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

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis("Horizontal"));

        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown((KeyCode)(KeyCode.JoystickButton0 + i)))
            {
                Debug.Log("JoystickButton" + i + " pressed");
            }
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
        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength, ForceMode.Impulse);

    }
}
