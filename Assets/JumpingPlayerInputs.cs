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
        CheckOptions();

        inputs.GameActions.Jump.performed += a => jumpingPlayer.Jump();
        //inputs.GameActions.Input.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());


        inputs.GameActions1.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions1.Input.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());


        inputs.GameActions2.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions2.MoveJumpVector.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());
        inputs.GameActions2.MovePlayerRight.canceled += a => jumpingPlayer.isMoving = false;
        inputs.GameActions2.MovePlayerLeft.canceled += a => jumpingPlayer.isMoving = false;


        inputs.GameActions3.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions3.MoveJumpVector.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());
        inputs.GameActions3.MovePlayerRight.canceled += a => jumpingPlayer.isMoving = false;
        inputs.GameActions3.MovePlayerLeft.canceled += a => jumpingPlayer.isMoving = false;


        inputs.GameActions4.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions4.MovePlayerRight.canceled += a => jumpingPlayer.isMoving = false;
        inputs.GameActions4.MovePlayerLeft.canceled += a => jumpingPlayer.isMoving = false;


        inputs.GameActions5.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions5.MovePlayerRight.canceled += a => jumpingPlayer.isMoving = false;
        inputs.GameActions5.MovePlayerLeft.canceled += a => jumpingPlayer.isMoving = false;


        inputs.GameActions6.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions6.Input.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());
        inputs.GameActions6.MoveState.canceled += a => jumpingPlayer.isMoving=false;



        inputs.GameActions1.DebugIsgrounded.performed += a => DebugIsGrounded();
        inputs.GameActions2.DebugIsgrounded.performed += a => DebugIsGrounded();
        inputs.GameActions3.DebugIsgrounded.performed += a => DebugIsGrounded();
        inputs.GameActions4.DebugIsgrounded.performed += a => DebugIsGrounded();
        inputs.GameActions5.DebugIsgrounded.performed += a => DebugIsGrounded();
        inputs.GameActions6.DebugIsgrounded.performed += a => DebugIsGrounded();
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

    // Update is called once per frame
    void Update()
    {
        CheckOptions();



        if (inputs.GameActions.MoveJumpVectorNegative.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorNegative();
        }
        if (inputs.GameActions.MoveJumpVectorPositive.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorPositive();
        }

        if (controlType == ControlType.option1)
        {
            if (inputs.GameActions1.Input.IsPressed())
            {
                jumpingPlayer.MovementAndJumpVector(jumpingPlayer.joystickVector);
            }
            if(jumpingPlayer.joystickVector == new Vector2(0,0))
            {
                jumpingPlayer.isMoving = false;
            }
        }



        if (controlType == ControlType.option2)
        {
            if (inputs.GameActions2.MovePlayerRight.IsPressed())
            {
                jumpingPlayer.MovePlayer(1);
            }
            if (inputs.GameActions2.MovePlayerLeft.IsPressed())
            {
                jumpingPlayer.MovePlayer(-1);
            }
            if (inputs.GameActions2.MoveJumpVector.IsPressed())
            {
                jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
            }
        }



        if (controlType == ControlType.option3)
        {
            if (inputs.GameActions3.MovePlayerRight.IsPressed())
            {
                jumpingPlayer.MovePlayer(1);
            }
            if (inputs.GameActions3.MovePlayerLeft.IsPressed())
            {
                jumpingPlayer.MovePlayer(-1);
            }
            if (inputs.GameActions3.MoveJumpVector.IsPressed())
            {
                jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
            }
        }



        if (inputs.GameActions4.MovePlayerRight.IsPressed())
        {
            jumpingPlayer.MovePlayer(1);
        }
        if (inputs.GameActions4.MovePlayerLeft.IsPressed())
        {
            jumpingPlayer.MovePlayer(-1);
        }
        if (inputs.GameActions4.MoveJumpVectorNegative.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorNegative();
        }
        if (inputs.GameActions4.MoveJumpVectorPositive.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorPositive();
        }



        if (inputs.GameActions5.MovePlayerRight.IsPressed())
        {
            jumpingPlayer.MovePlayer(1);
        }
        if (inputs.GameActions5.MovePlayerLeft.IsPressed())
        {
            jumpingPlayer.MovePlayer(-1);
        }
        if (inputs.GameActions5.MoveJumpVectorNegative.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorNegative();
        }
        if (inputs.GameActions5.MoveJumpVectorPositive.IsPressed())
        {
            jumpingPlayer.IncrementalMoveJumpVectorPositive();
        }



        if (controlType == ControlType.option6)
        {
            if (inputs.GameActions6.Input.IsPressed())
            {
                jumpingPlayer.MoveJumpVectorV3(jumpingPlayer.joystickVector);
            }
            if(inputs.GameActions6.MoveState.IsPressed())
            {
                jumpingPlayer.MoveState(1);
            }
        }
    }

    private void CheckOptions()
    {
        switch (controlType)
        {
            case ControlType.PC:
                inputs.GameActions.Enable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option1:
                inputs.GameActions.Disable();
                inputs.GameActions1.Enable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option2:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Enable();
                inputs.GameActions3.Enable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option3:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Enable();
                inputs.GameActions3.Enable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option4:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Enable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option5:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Enable();
                inputs.GameActions6.Disable();
                break;
            case ControlType.option6:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Enable();
                break;
        }
    }

}
