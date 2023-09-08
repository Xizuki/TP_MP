
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


        CheckOptions();

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
        //else if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    controlType = ControlType.PC;
        //}
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
        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    controlType = ControlType.option5;
        //}




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

        //if (inputs.GameActions.MoveJumpVectorNegative.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorNegative();
        //}
        //if (inputs.GameActions.MoveJumpVectorPositive.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorPositive();
        //}

        //if (controlType == ControlType.option1)
        //{
        //    if (inputs.GameActions1.Input.IsPressed())
        //    {
        //        jumpingPlayer.MovementAndJumpVector(jumpingPlayer.joystickVector);
        //    }
        //    if(jumpingPlayer.joystickVector == new Vector2(0,0))
        //    {
        //        jumpingPlayer.isMoving = false;
        //    }
        //}



        //if (controlType == ControlType.option2)
        //{
        //    if (inputs.GameActions2.MovePlayerRight.IsPressed())
        //    {
        //        jumpingPlayer.MovePlayer(1);
        //    }
        //    if (inputs.GameActions2.MovePlayerLeft.IsPressed())
        //    {
        //        jumpingPlayer.MovePlayer(-1);
        //    }
        //    if (inputs.GameActions2.MoveJumpVector.IsPressed())
        //    {
        //        jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
        //    }
        //}



        //if (controlType == ControlType.option3)
        //{
        //    if (inputs.GameActions3.MovePlayerRight.IsPressed())
        //    {
        //        jumpingPlayer.MovePlayer(1);
        //    }
        //    if (inputs.GameActions3.MovePlayerLeft.IsPressed())
        //    {
        //        jumpingPlayer.MovePlayer(-1);
        //    }
        //    if (inputs.GameActions3.MoveJumpVector.IsPressed())
        //    {
        //        jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
        //    }
        //}



        //if (inputs.GameActions4.MovePlayerRight.IsPressed())
        //{
        //    jumpingPlayer.MovePlayer(1);
        //}
        //if (inputs.GameActions4.MovePlayerLeft.IsPressed())
        //{
        //    jumpingPlayer.MovePlayer(-1);
        //}
        //if (inputs.GameActions4.MoveJumpVectorNegative.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorNegative();
        //}
        //if (inputs.GameActions4.MoveJumpVectorPositive.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorPositive();
        //}



        //if (inputs.GameActions5.MovePlayerRight.IsPressed())
        //{
        //    jumpingPlayer.MovePlayer(1);
        //}
        //if (inputs.GameActions5.MovePlayerLeft.IsPressed())
        //{
        //    jumpingPlayer.MovePlayer(-1);
        //}
        //if (inputs.GameActions5.MoveJumpVectorNegative.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorNegative();
        //}
        //if (inputs.GameActions5.MoveJumpVectorPositive.IsPressed())
        //{
        //    jumpingPlayer.IncrementalMoveJumpVectorPositive();
        //}



        //if (controlType == ControlType.option6)
        //{
        //    if (inputs.GameActions6.Input.IsPressed())
        //    {
        //        jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
        //    }
        //    if(inputs.GameActions6.MoveState.IsPressed())
        //    {
        //        jumpingPlayer.MoveState(1);
        //    }
        //}
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
                //    case ControlType.PC:
                //        inputs.GameActions.Enable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Disable();
                //        inputs.GameActions3.Disable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option1:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Enable();
                //        inputs.GameActions2.Disable();
                //        inputs.GameActions3.Disable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option2:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Enable();
                //        inputs.GameActions3.Enable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option3:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Enable();
                //        inputs.GameActions3.Enable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option4:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Disable();
                //        inputs.GameActions3.Disable();
                //        inputs.GameActions4.Enable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option5:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Disable();
                //        inputs.GameActions3.Disable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Enable();
                //        inputs.GameActions6.Disable();
                //        break;
                //    case ControlType.option6:
                //        inputs.GameActions.Disable();
                //        inputs.GameActions1.Disable();
                //        inputs.GameActions2.Disable();
                //        inputs.GameActions3.Disable();
                //        inputs.GameActions4.Disable();
                //        inputs.GameActions5.Disable();
                //        inputs.GameActions6.Enable();
                //        break;
        }
    }

}
