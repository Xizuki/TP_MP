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
    public ParticleSystem jumpParticle;
    public ParticleSystem hitParticle;
    public Animator animator;

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
        if (Input.GetKey(KeyCode.Q))
        {
            jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
        }
        if(jumpCharge > 1)
        {
            jumpCharge = 1;
        }

        print("rb.velocity.normalized.y = " + rb.velocity.normalized.y);

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
        if (!isGrounded || jumpCharge <= 0) { return; }
        //float forceCalcs = TransformValue(rbJumpStrength * jumpCharge, scalar);
        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength * NonLinearScaledValue(jumpCharge,jumpChargeScalar), ForceMode.Impulse);
        jumpCharge = 0;
        isGrounded = false;
        SFX.jumpSound = true;
        animator.SetTrigger("Jump");
        Instantiate(jumpParticle, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Very Simple, could maybe have bugs
        if (collision.contacts[0].point.y <= feetPos.position.y)
        {
            isGrounded = true;
            print("collision.impulse.magnitude/38 = " + collision.impulse.magnitude / 35);

            CameraShaker.Invoke(collision.impulse.magnitude / 35); //To set if screenshake is turned
            ComboCount.combo += 1;
            ComboCount.hit = true;
            SFX.scoreSound = true;
            SFX.landSound = true;
            Tweening.comboUp = true;
        }
        else if (collision.contacts[0].point.y > feetPos.position.y)
        {
            ComboCount.hit = false;
        }
        if(collision.collider.tag == "Enemy")
        {
            animator.SetTrigger("Hit");
            hitParticle.Play();
        }
    }

}
