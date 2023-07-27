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

    public bool resetChargeOnMove;

    public float moveSpeed;
    public float jumpCharge;
    public float jumpChargePrev;
    public float jumpChargeSpeedCurrent;
    public float jumpChargeSpeedMax;
    public bool isCharging;
    public Vector2 jumpAngleVector;
    public float rbJumpStrength;
    public ParticleSystem jumpParticle;
    public ParticleSystem hitParticle;
    public ParticleSystem chargeParticle;
    public ParticleSystem chargeTapParticle;
    public ParticleSystem chargeTapParticle2;

    public Animator animator;
    public Chicken chicken;
    public GameObject chickenExit;

    public Collider shibaCollider;
    public int hitStrength = 15;
    public bool isGrounded;
    public bool isJumping;
    public bool isMoving;

    public Transform feetPos;
    public float fallingGravityStrength;
    public float jumpChargeScalar;


    public bool faceFront = false;//Used to determine if should face front
    public bool recentInput;// Used to check if there has been input recently
    [SerializeField]
    private float checkInputDelay = 1f; //How long before 'isInput' is reset
    private float checkInputDelayCountdown = 1f;
    public bool canRotate = true; //Used to lock rotations

    public Vector2 joystickVector;
    public void Awake()
    {
        inputs = new ControllerInput();
        rb = GetComponent<Rigidbody>();
        playerUI = GetComponent<JumpingPlayerUIScript>();

        //inputs.GameActions.Enable();

        //inputs.GameActions.Jump.performed += a => Jump();
        //inputs.GameActions.Input.performed += a => SetJoyStickVector2(a.ReadValue<Vector2>());
    }



    // Start is called before the first frame update
    void Start()
    {
        shibaCollider = gameObject.GetComponent<BoxCollider>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Timer();
        ResetInputCountdown();
        
        chickenExit.transform.position = new Vector3(chickenExit.transform.position.x, transform.position.y + 20f, chickenExit.transform.position.z);

        Inputs();

        jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, -playerUI.jumpingVectorIndicator.transform.eulerAngles.z, 0);

        if (!chicken.playerDowned)
            rb.AddForce(new Vector3(0, -fallingGravityStrength * Time.deltaTime * 100, 0));
    }


    // Example 1-((1-0.5)^5)
    public float NonLinearScaledValue(float value, float scalar)
    {
        float scaledValue = (float)(1 - Mathf.Pow(1 - value, scalar));
        return scaledValue;
    }

    private void Inputs()
    {
        // NEED TO FIX ANIMATIONS LINKING IT TO THE ISCHARGING BOOLEAN
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("Charge", true);
            isCharging = true;
            canRotate = false;//Logic for rotation when charging
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isCharging = false;
            canRotate = true;//Logic for rotation when charging
            animator.SetBool("Charge", false);

        }
        if (isGrounded && !isMoving)
        {
            if (isCharging)
            {
                chargeParticle.Play();
                jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
                chargeTapParticle.Play();
                chargeTapParticle2.Play();
            }
            if (!isCharging)
            {
                chargeParticle.Stop();
            }
        }
        if(jumpCharge > 1)
        {
            jumpCharge = 1;
        }



     
    }



    public void SetJoyStickVector2(Vector2 vector)
    {
        joystickVector = vector;
    }
    public void MovePlayer(int value)
    {
        if (!isGrounded || chicken.playerDowned) return;

        transform.position += new Vector3(value * moveSpeed, 0f, 0f)  * Time.deltaTime;
        rb.velocity += new Vector3(value * moveSpeed, 0f, 0f)  * Time.deltaTime;

        if(resetChargeOnMove)
            jumpCharge = 0;
        isMoving = true;
    }

    public void MovementAndJumpVector(Vector2 v2)
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay; //Resets input countdown 
        recentInput = false;

        // Can make this less hard coded but idk how rn and abit laze 
        playerUI.jumpingVectorIndicator.transform.up = new Vector3(-v2.x, v2.y, 0);
        playerUI.jumpingVectorIndicator.transform.localEulerAngles = new Vector3(playerUI.jumpingVectorIndicator.transform.eulerAngles.x, 0, playerUI.jumpingVectorIndicator.transform.eulerAngles.z);

        if (LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.playerJumpVectorIndicatorHardAngleLimit) && isGrounded)
        {
            transform.position += new Vector3(v2.x, 0, 0) * Time.deltaTime * moveSpeed;

            if (resetChargeOnMove)
                jumpCharge = 0;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    public void MoveJumpVectorV3(Vector2 v2)
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay; //Resets input countdown 
        recentInput = false;
        
        
        // Can make this less hard coded but idk how rn and abit laze 
        playerUI.jumpingVectorIndicator.transform.up = new Vector3(-v2.x, v2.y, 0);
        playerUI.jumpingVectorIndicator.transform.localEulerAngles = new Vector3(playerUI.jumpingVectorIndicator.transform.eulerAngles.x,0, playerUI.jumpingVectorIndicator.transform.eulerAngles.z);


        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);
    }
    public void IncrementalMoveJumpVectorNegative()
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay; //Resets input countdown 
        MoveJumpVectorNegative();
        recentInput = false;


        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);

    }
    public void IncrementalMoveJumpVectorPositive()
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay;//Resets input countdown 
        MoveJumpVectorPositive();
        recentInput = false;

        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);
    }

    public bool LimitJumpVectorAngle(bool forceLock, float checkLimitAngle, float visualLimitAngle)
    {
        float angle = playerUI.jumpingVectorIndicator.transform.eulerAngles.z;
        float negative = angle >= 180 ? -1 : 1;
        angle = angle >= 180 ? 180 - (angle % 180) : angle;

        if (angle > checkLimitAngle + Time.deltaTime)
        {
            if(forceLock && angle > visualLimitAngle + Time.deltaTime)
                playerUI.jumpingVectorIndicator.transform.localEulerAngles = new Vector3(0, 0, visualLimitAngle * negative);
            return true;
        }

        return false;
    }
    public void MoveState(float scale)
    {
        if (!isGrounded) return;

        transform.position += new Vector3(playerUI.jumpingVectorIndicator.transform.up.x* scale * moveSpeed, 0, 0)*Time.deltaTime;

        if (resetChargeOnMove)
            jumpCharge = 0;
        isMoving = true;
    }


    private void Timer() //Timer goes down when no input
    {
        //if(recentInput==true)
        //{
        //    Debug.Log("Have Input!");
        //    checkInputDelayCountdown = checkInputDelay;
        //}
        if (checkInputDelayCountdown > 0 && recentInput == false)
        {
            checkInputDelayCountdown -= Time.deltaTime;
        }
    }
    private void ResetInputCountdown()// Timer resets and makes character face front
    {
        if (checkInputDelayCountdown <= 0)
        {
            faceFront = true;
            checkInputDelayCountdown = checkInputDelay;
        }

    }

    private void MoveJumpVectorNegative()
    {
        playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, -1) * Time.deltaTime * playerUI.jumpVectorRotationSpeed;
    }
    private void MoveJumpVectorPositive()
    {
        playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * playerUI.jumpVectorRotationSpeed;
    }
    public void Jump()
    {
        if (!isGrounded || chicken.playerDowned || jumpCharge <= 0) { return; }
        //float forceCalcs = TransformValue(rbJumpStrength * jumpCharge, scalar);
        transform.position += new Vector3(0, 0.01f, 0);
        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength * NonLinearScaledValue(jumpCharge, jumpChargeScalar), ForceMode.Impulse);

        jumpChargePrev = jumpCharge;
        jumpCharge = 0;
        isGrounded = false;

        SFX.jumpSound = true;
        animator.SetTrigger("Jump");
        Instantiate(jumpParticle, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Very Simple, could maybe have bugs
        if (collision.contacts[0].point.y <= feetPos.position.y && !chicken.playerDowned)
        {
            isGrounded = true;

            ///* Moved to PlatformManager 
            CameraShaker.Invoke(collision.impulse.magnitude / 35); //To set if screenshake is turned
            //ComboCount.combo += 1;
            print("collision.impulse.magnitude / 35 = " + (collision.impulse.magnitude / 35));
            //ComboCount.hit = true;
            //SFX.scoreSound = true;
            //SFX.landSound = true;
            //Tweening.comboUp = true;

            if (collision.gameObject.GetComponent<PlatformScript>() == true)
            {
                PlatformManager.instance.SetLastLandedPlatform(collision.gameObject.GetComponent<PlatformScript>());
            }
        }
        else if (collision.contacts[0].point.y > feetPos.position.y)
        {
            //ComboCount.hit = false;
        }
        if (collision.collider.tag == "Enemy")
        {
            animator.SetTrigger("Hit");
            hitParticle.Play();
            HitPhase();
        }
    }

    private void HitPhase()
    {
        isGrounded = false;
        Time.timeScale = 0;
        shibaCollider.enabled = false;
        rb.AddForce(new Vector3(0, hitStrength, 0), ForceMode.Impulse);
        StartCoroutine(StartDelay());
    }



    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("Back");
        Time.timeScale = 1;
    }
}
