/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(JumpingPlayerUIScript))]
public class JumpingPlayerScriptOriginal : MonoBehaviour
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
<<<<<<< HEAD
=======
    public ParticleSystem jumpParticle;
    public ParticleSystem hitParticle;
    public ParticleSystem chargeParticle;
    public Animator animator;
>>>>>>> Joakhem_branch_new2

    public bool isGrounded;
    public bool isJumping;
    public Transform feetPos;
    public float fallingGravityStrength;
    public float jumpChargeScalar;
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
        Inputs();

        jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0,-playerUI.jumpingVectorIndicator.transform.eulerAngles.z,0);

        // better isGrounded Check
        //if(!isGrounded)
        if(rb.useGravity == true)
            rb.AddForce(new Vector3(0, -fallingGravityStrength * Time.deltaTime * 100, 0));
    }
 
     


    private void Inputs()
    {
        if (isGrounded)
        {
<<<<<<< HEAD
            if (Input.GetKey(KeyCode.Q))
            {
                jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
            }
            if (jumpCharge > 1)
            {
                jumpCharge = 1;
            }
        }


=======
            chargeParticle.Play();
            jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Charging");
            animator.SetBool("Charge", true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            chargeParticle.Stop();
            animator.SetBool("Charge", false);
        }
        if(jumpCharge > 1)
        {
            jumpCharge = 1;
        }

>>>>>>> Joakhem_branch_new2
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
    public void Jump()
    {
        print("JUMP Pressed");
        if (!isGrounded || jumpCharge <= 0) { return; }
        print("JUMP Pressed2");

        //float forceCalcs = TransformValue(rbJumpStrength * jumpCharge, scalar);
        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength * XizukiMethods.Numbers.Xi_Helper_Nums.ScaleNonLinearly(jumpCharge,jumpChargeScalar), ForceMode.Impulse);
        jumpCharge = 0;
        isGrounded = false;
        SFX.jumpSound = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Very Simple, could maybe have bugs

        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.point.y <= feetPos.position.y)
            {
                if (collision.gameObject.tag != "Platform") { return; }

                isGrounded = true;

                PlatformManager.instance.SetLastLandedPlatform(collision.gameObject.GetComponent<PlatformScript>());

                print("collision.impulse.magnitude/38 = " + collision.impulse.magnitude / 35);

                CameraShaker.Invoke(collision.impulse.magnitude / 35); //To set if screenshake is turned
                ComboCount.combo += 1;
                ComboCount.hit = true;
                SFX.scoreSound = true;
                SFX.landSound = true;
            }
            else if (collision.contacts[0].point.y > feetPos.position.y)
            {
                ComboCount.hit = false;
            }
        }
    }
    */
    /*
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.point.y <= feetPos.position.y)
            {
                isGrounded = true;
            }
        }
    }
    */
//}
