
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ControlType { PC ,option1, option2, option3, option4, option5, option6 }
public class JumpingPlayerInputs : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;

    public ControlType controlType;

    public ControllerInput inputs;
    private void Awake()
    {
        inputs = new ControllerInput();

        jumpingPlayer = GetComponent<JumpingPlayerScript>();

        inputs.GameActions.Jump.performed += a => jumpingPlayer.Jump();
        
        inputs.Rework1.Jump.performed += a => jumpingPlayer.Jump();
        inputs.Rework1.Left.canceled += a => jumpingPlayer.isMoving = false;
        inputs.Rework1.Right.canceled += a => jumpingPlayer.isMoving = false;

        inputs.Rework1.DebugIsgrounded.performed -= a => DebugIsGrounded();

        baseSpeed = jumpingPlayer.moveSpeed;
        option2Speed = baseSpeed * 2;
        baseJumpVectorLimit = jumpingPlayer.playerUI.jumpingVectorAngleLimit;
        option3JumpVectorLimit = baseJumpVectorLimit - 15f;
    }

    public void DebugIsGrounded()
    {
        jumpingPlayer.isJumping = false;
        jumpingPlayer.isMoving = false;
        jumpingPlayer.isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private float baseSpeed;
    private float option2Speed;
    private float baseJumpVectorLimit;
    public float option3JumpVectorLimit;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DebugIsGrounded();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controlType = ControlType.option1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controlType = ControlType.option2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controlType = ControlType.option3;
        }




        CheckOptions();



        if (inputs.Rework1.Left.IsPressed())
        {
            if(controlType == ControlType.option1)
                jumpingPlayer.Left1();
            if (controlType == ControlType.option2)
                jumpingPlayer.Left2(-1.5f);
            if (controlType == ControlType.option3)
                jumpingPlayer.Left3();
        }
        if (inputs.Rework1.Right.IsPressed())
        {
            if (controlType == ControlType.option1)
                jumpingPlayer.Right1();
            if (controlType == ControlType.option2)
                jumpingPlayer.Right2(1.5f);
            if (controlType == ControlType.option3)
                jumpingPlayer.Right3();
        }

    }

    private void CheckOptions()
    {
        switch (controlType)
        {
            case ControlType.option1:
                inputs.Rework1.Enable();
                jumpingPlayer.moveSpeed = baseSpeed;
                jumpingPlayer.playerUI.jumpingVectorAngleLimit = baseJumpVectorLimit;
                break;
            case ControlType.option2:
                inputs.Rework1.Enable();
                jumpingPlayer.moveSpeed = option2Speed;
                jumpingPlayer.playerUI.jumpingVectorAngleLimit = baseJumpVectorLimit;
                break;
            case ControlType.option3:
                inputs.Rework1.Enable();
                jumpingPlayer.moveSpeed = baseSpeed;
                jumpingPlayer.playerUI.jumpingVectorAngleLimit = option3JumpVectorLimit;
                break;
            
        }
    }

}
