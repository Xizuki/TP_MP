using System;
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
    public FullChargeHit fullChargeHit;
    public Vector3 playerTransform;

    public float lineLength = 10f;
    public bool checkLandSound; //Checking for sound effect when successfully landing
    public bool checkMaxChargeSoundSfx;

    public float initialForce;
    public float InitialAngle;
    public float jumpCharge;
    public float jumpChargePrev;

    public float jumpChargeSpeedCurrent;
    public float jumpChargeSpeedReduction;
    public float jumpChargeSpeedMax;
    public bool isCharging;
    public Vector2 jumpAngleVector;
    public float rbJumpStrength;
    public ParticleSystem jumpParticle;
    public ParticleSystem hitParticle;
    public ParticleSystem chargeParticle;
    public ParticleSystem chargeTapParticle;
    public ParticleSystem chargeTapParticle2;
    public ParticleSystem maxParticle;

    public ParticleSystem maxChargeParticleOut;
    public ParticleSystem maxChargeParticleIn;

    public Animator animator;
    public Chicken chicken;
    public GameObject chickenExit;

    public Collider shibaCollider;
    public float moveSpeed;
    public int hitStrength = 5;
    public int i = 0;
    public bool isGrounded;
    public bool isJumping;
    public bool isMoving;
    public bool resetChargeOnMove;

    public Transform feetPos;
    public float fallingGravityStrength;
    public float jumpChargeScalar;

    public static bool fullyCharge;

    public bool faceFront = false;//Used to determine if should face front
    public bool recentInput;// Used to check if there has been input recently
    [SerializeField]
    private float checkInputDelay = 1f; //How long before 'isInput' is reset
    [SerializeField]
    private float checkInputDelayCountdown = 1f;
    public bool canRotate = true; //Used to lock rotations

    public Vector2 joystickVector;

    public float chargeCount;
    public float timeSinceCharge;
    public float chargeCountSoundSFXCooldown = 1f;


    public void Awake()
    {
        chicken= GameObject.FindObjectOfType(typeof(Chicken)) as Chicken;
        chickenExit = GameObject.FindGameObjectWithTag("ExitPoint");


        inputs = new ControllerInput();
        rb = GetComponent<Rigidbody>();
        playerUI = GetComponent<JumpingPlayerUIScript>();
        fullChargeHit = GetComponent<FullChargeHit>();
        int playerLayer = rb.gameObject.layer;
      
    }



    // Start is called before the first frame update
    void Start()
    {
        shibaCollider = gameObject.GetComponent<BoxCollider>();
    }
    

    // Update is called once per frame
    void LateUpdate()
    {
        if(isMoving == true)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        Timer();
        ResetInputCountdown();
            
      

        chickenExit.transform.position = new Vector3(chickenExit.transform.position.x, transform.position.y +15f, chickenExit.transform.position.z);

        Inputs();

        jumpingPlayerChildrenModel.transform.localEulerAngles = new Vector3(0, -playerUI.jumpingVectorIndicator.transform.eulerAngles.z, 0);

        if (chargeCount < 0f)
        {
            chargeCount = 0f;
        }
        if (chargeCount > 5f)
        {
            chargeCount = 5f;
        }



        if (jumpCharge > 0)
        {
            jumpCharge -= Time.deltaTime * jumpChargeSpeedCurrent / jumpChargeSpeedReduction;
        }

        chargeCountSoundSFXCooldown -= 1 * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        
        if (!chicken.playerDowned)
           rb.AddForce(new Vector3(0, (-fallingGravityStrength * Time.deltaTime * 100) , 0));

        playerTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 3.0f);

        gameObject.transform.position = playerTransform;
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
        if (Input.GetKey(KeyCode.Q))
        {
            isCharging = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isCharging = false;
        }


        if (!isCharging)
        {
            SFX.performanceCharge = false;
        }

        if (isGrounded)
        {
            if (isCharging)
            {
                animator.SetBool("Charge", true);
                SFX.charging = true; //Added charging SFX
                canRotate = false;//Logic for rotation when charging

                chargeParticle.Play();
                chargeCount += 3f * Time.deltaTime;
                jumpCharge += Time.deltaTime * jumpChargeSpeedCurrent;
                SFX.performanceCharge = true;
                chargeCountSoundSFXCooldown = 1f;

                recentInput = true;;
            }
            if (!isCharging)
            {
                canRotate = true;//Logic for rotation when charging
                animator.SetBool("Charge", false);

                SFX.performanceCharge = false;
                chargeCount -= 0.55f * Time.deltaTime; //chargecount 
                chargeParticle.Stop();
                maxChargeParticleOut.Stop();
            }
        }
        if (jumpCharge > 0.1 && isCharging)
        {
            if (checkMaxChargeSoundSfx == false)
            {
                checkMaxChargeSoundSfx = true;
                SFX.contiCharging = true;
                Debug.Log(chargeCount);
                StartCoroutine(maxChargeSfx());
                fullyCharge = true;
            }
        }
        if (jumpCharge >= 0.85)
        {
            maxChargeParticleIn.Play();
        }
        if (jumpCharge < 0.85)
        {
            maxChargeParticleIn.Stop();
        }
        if (jumpCharge < 1)
        {
            fullyCharge = false;
            PulseVfx.playerPulse = false;
        }
        if (jumpCharge > 1)
        {

            PulseVfx.playerPulse = true;
            jumpCharge = 1;
            maxChargeParticleIn.Play();
            maxChargeParticleOut.Play();
            }

        IEnumerator maxChargeSfx()
        {
            yield return new WaitForSeconds(0.25f);
            checkMaxChargeSoundSfx = false;
        }
     
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

    public void MoveJumpVectorV3(Vector2 v2)
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay; //Resets input countdown 
        //recentInput = false;
        
        
        // Can make this less hard coded but idk how rn and abit laze 
        playerUI.jumpingVectorIndicator.transform.up = new Vector3(-v2.x, v2.y, 0);
        playerUI.jumpingVectorIndicator.transform.localEulerAngles = 
            new Vector3(playerUI.jumpingVectorIndicator.transform.eulerAngles.x,0, 
            playerUI.jumpingVectorIndicator.transform.eulerAngles.z);


        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);
    }
    public void IncrementalMoveJumpVectorNegative()
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay; //Resets input countdown 
        MoveJumpVector(-1);
        //recentInput = false;


        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);

    }
    public void IncrementalMoveJumpVectorPositive()
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay;//Resets input countdown 
        MoveJumpVector(1); 
        //recentInput = false;


        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);
    }
    public void IncrementalMoveJumpVector(float value)
    {
        //recentInput = true;
        faceFront = false;
        checkInputDelayCountdown = checkInputDelay;//Resets input countdown 
        MoveJumpVector(value);
        //recentInput = false;



        MovePlayer((int)value);
        LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit);
    }

    public void IncrementalMoveJumpVectorAndMovement(float value)
    {
        recentInput = true;
        //faceFront = false;
        checkInputDelayCountdown = checkInputDelay;//Resets input countdown 
        MoveJumpVector(value);
        //recentInput = false;


        if (LimitJumpVectorAngle(true, playerUI.jumpingVectorAngleLimit, playerUI.jumpingVectorAngleLimit))
        {
            MovePlayer((int)(value / Mathf.Abs(value)));
        }
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
        if (checkInputDelayCountdown > 0 && recentInput)
        {
            checkInputDelayCountdown -= Time.deltaTime;
            faceFront = false;
        }
    }
    private void ResetInputCountdown()// Timer resets and makes character face front
    {
        if (checkInputDelayCountdown <= 0 && recentInput)
        {
            faceFront = true;
            checkInputDelayCountdown = checkInputDelay;
            recentInput = false;
        }

    }

    private void MoveJumpVector(float value)
    {
        Vector3 increment = new Vector3(0, 0, value) * Time.deltaTime * playerUI.jumpVectorRotationSpeed;
        playerUI.jumpingVectorIndicator.transform.localEulerAngles += increment;
    }


    public void Jump()
    {
        if (!isGrounded || chicken.playerDowned || jumpCharge <= 0) { return; }

        rb.AddForce(playerUI.jumpingVectorIndicator.transform.up.normalized 
            * rbJumpStrength * NonLinearScaledValue(jumpCharge, jumpChargeScalar), ForceMode.Impulse);
       
        jumpChargePrev = jumpCharge;
        jumpCharge = 0;
        isGrounded = false;
        isJumping = true;

        SFX.jumpSound = true;
        SFX.voiceJump = true; //Added jumping voice

        animator.SetTrigger("Jump");
        Instantiate(jumpParticle, transform.position, transform.rotation);
    }


    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            // Very Simple, could maybe have bugs
            if (collision.contacts[0].point.y <= feetPos.position.y && !chicken.playerDowned)
            {
                if (collision.impulse.y <= 0) { return; }
                isGrounded = true;
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Very Simple, could maybe have bugs
        for (int i = 0; i < collision.contacts.Length; i++)
        {

            if (collision.contacts[i].point.y <= feetPos.position.y && !chicken.playerDowned)
            {
                isGrounded = true;
                isJumping = false;

                if (checkLandSound == false)
                {
                    SFX.landSound = true;
                    checkLandSound = true;
                }

                CameraShaker.Invoke(collision.impulse.magnitude / 35); //To set if screenshake is turned
           
                if (collision.gameObject.GetComponent<PlatformScript>() == true)
                {
                    PlatformManager.instance.SetLastLandedPlatform(collision.gameObject.GetComponent<PlatformScript>());
                    fullChargeHit.Landing(collision);
                    jumpChargePrev = 0;
                }
            }
            else if (collision.contacts[0].point.y > feetPos.position.y)
            {
                    checkLandSound = false;
            }
            if (collision.collider.tag == "Enemy" || collision.collider.tag == "EnemyBullet" || collision.collider.tag == "ChestEnemy")
            {
                animator.SetTrigger("Hit");
                hitParticle.Play();

                if (!GetComponent<ShieldPowerUp>().isActivated)
                {
                    HitPhase();
                }
                GameObject.Instantiate(GetComponentInChildren<InvulnerableJump>().explosion, 
                    collision.transform.position, 
                    collision.transform.rotation);

                if(collision.collider.tag == "EnemyBullet")
                {
                    if (!GetComponent<ShieldPowerUp>().CollisionCheck(collision))
                    {
                        Destroy(collision.collider.GetComponent<BulletMove>().owner.GetComponentInParent<EnemyScript>().gameObject);
                        GameObject.Instantiate(GetComponentInChildren<InvulnerableJump>().explosion, 
                            collision.collider.GetComponent<BulletMove>().owner.transform.position, collision.transform.rotation);
                    }
                }
                else Destroy(collision.gameObject);

            }

        }
    }

    public void Left1()
    {
        IncrementalMoveJumpVector(-2.25f);
        MovePlayer(-1);
    }

    public void Right1()
    {
        IncrementalMoveJumpVector(2.25f);
        MovePlayer(1);
    }

    public void Left2(float value)
    {
        IncrementalMoveJumpVectorAndMovement(value);
    }

    public void Right2(float value)
    {
        IncrementalMoveJumpVectorAndMovement(value);
    }

    public void Left3()
    {
        MovePlayer(-1);

        Vector3 platformPos = PlatformManager.instance.lastLandedPlatform.transform.position;
        MoveJumpVectorV3((transform.position - platformPos).normalized);
    }

    public void Right3()
    {
        MovePlayer(1);

        Vector3 platformPos = PlatformManager.instance.lastLandedPlatform.transform.position;
        MoveJumpVectorV3((transform.position - platformPos).normalized);
    }

    private void HitPhase()
    {
        isGrounded = false;
        Time.timeScale = 0;
        shibaCollider.enabled = false;
        rb.AddForce(new Vector3(0, hitStrength, 0), ForceMode.Impulse);
        StartCoroutine(StartDelay());
        SFX.hit = true;
    }



    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(0.15f); //Reduced the delay 0.5 -> 0.15
        Debug.Log("Back");
        Time.timeScale = 1;
    }


}
