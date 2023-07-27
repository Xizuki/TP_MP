using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum controlType { PC ,option1, option2, option3, option4, option5, option6 }
public class JumpingPlayerInputs : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public controlType controlType;
    public ControllerInput inputs;

    private void Awake()
    {
        inputs = new ControllerInput();

        jumpingPlayer = GetComponent<JumpingPlayerScript>();
        CheckOptions();

        inputs.GameActions.Jump.performed += a => jumpingPlayer. Jump();
        //inputs.GameActions.Input.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());


        inputs.GameActions1.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions1.Input.performed += a => jumpingPlayer.SetJoyStickVector2(a.ReadValue<Vector2>());

        inputs.GameActions2.Jump.performed += a => jumpingPlayer.Jump();
        inputs.GameActions2.MoveJumpVector.performed += a => jumpingPlayer.MoveJumpVectorV3(a.ReadValue<Vector2>());
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

        if (inputs.GameActions2.MovePlayerRight.IsPressed())
        {
            jumpingPlayer.MovePlayer(1);
        }
        if (inputs.GameActions2.MovePlayerLeft.IsPressed())
        {
            jumpingPlayer.MovePlayer(-1);
        }

        
    }
    private void CheckOptions()
    {
        switch (controlType)
        {
            case controlType.PC:
                inputs.GameActions.Enable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option1:
                inputs.GameActions.Disable();
                inputs.GameActions1.Enable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option2:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Enable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option3:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Enable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option4:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Enable();
                inputs.GameActions5.Disable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option5:
                inputs.GameActions.Disable();
                inputs.GameActions1.Disable();
                inputs.GameActions2.Disable();
                inputs.GameActions3.Disable();
                inputs.GameActions4.Disable();
                inputs.GameActions5.Enable();
                inputs.GameActions6.Disable();
                break;
            case controlType.option6:
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
