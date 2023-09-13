using UnityEngine;
using UnityEngine.UI;

public class JumpingPlayerCameraScript : MonoBehaviour
{
    public JumpingPlayerScript jumpingPlayer;
    public JumpingPlayerUIScript playerUI;
    public float yOffset;
    public float highestY;
    public float platformHeightOffset = 1;

    public Color screenVFXStartColor;
    public Color screenVFXEndColor;
    public float jumpChargeValueStorage4FOVDecaySpeed;
    public float jumpChargeValueStorage4ScreenVFXDecaySpeed;
    public float jumpChargeValueStorage4FOV;
    public float jumpChargeValueStorage4ScreenVFX;
    public float jumpChargeFOVDiff;
    public float jumpChargeScreenVFXScaleDiff;
    public float jumpChargeArrowScaleDiff;




    public Image jumpChargeScreenVFX;

    // Start is called before the first frame update
    void Start()
    {
        jumpChargeScreenVFX = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>().jumpChargeScreenVFX;

        jumpingPlayer = GameObject.FindObjectOfType<JumpingPlayerScript>();
        playerUI = jumpingPlayer.playerUI;

        baseFOV = Camera.main.fieldOfView;
        baseArrowScale = playerUI.arrows[0].GetComponentInChildren<RectTransform>().localScale.x;

        arrowsCharged = new bool[playerUI.arrows.Length];
        arrowEndPoints = new Transform[playerUI.arrows.Length];

        for(int i = 0; i < playerUI.arrows.Length; i++) 
        {
            arrowEndPoints[i] = playerUI.arrows[i].GetComponentInChildren<ArrowEndPoint>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VFXOnCharge();

        CameraPositioning();
    }

    private float baseFOV;
    private float baseArrowScale;
    public bool[] arrowsCharged;
    public Transform[] arrowEndPoints;
    bool arrowScalingStarted;



    // All The VFX that happens on charge
    public void VFXOnCharge()
    {
        #region Screen VFX and Camera FOV effects
        // NEED BETTER WAY TO DO THIS, EASING VARIABLES
        // stores jumpcharge value to be used in VFX as jumpCharge instantly goes to 0 after player jumps
        if (jumpingPlayer.jumpCharge > 0 && jumpingPlayer.isGrounded)
        {
            jumpChargeValueStorage4FOV = jumpingPlayer.jumpCharge;
            jumpChargeValueStorage4ScreenVFX = jumpingPlayer.jumpCharge;
        }

        // incrementally reduce the FOV of the camera back to its base amount after the player lands 
        if (jumpingPlayer.jumpChargePrev == 0 && jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4FOV > 0)
            jumpChargeValueStorage4FOV -= jumpChargeValueStorage4FOVDecaySpeed * Time.deltaTime;

        // incrementally reduce the screen VFX scale and color back to its base amounts right after player jumps
        if (jumpingPlayer.jumpCharge == 0 && jumpChargeValueStorage4ScreenVFX > 0 && !jumpingPlayer.isGrounded)
            jumpChargeValueStorage4ScreenVFX -= jumpChargeValueStorage4ScreenVFXDecaySpeed * Time.deltaTime;


        // Final Values for FOV,Sizes and Color
        float jumpChargeFOVValue = baseFOV + ((jumpChargeValueStorage4FOV) * jumpChargeFOVDiff);
        float jumpChargeScreenVFXValue = 1 + ((jumpChargeValueStorage4ScreenVFX) * jumpChargeScreenVFXScaleDiff);

        // Update The Actual GameObjects with Final Values
        jumpChargeScreenVFX.color = Color.Lerp(screenVFXStartColor, screenVFXEndColor, jumpChargeValueStorage4ScreenVFX);
        jumpChargeScreenVFX.rectTransform.localScale = new Vector3(jumpChargeScreenVFXValue, jumpChargeScreenVFXValue, jumpChargeScreenVFXValue);
        Camera.main.fieldOfView = jumpChargeFOVValue;
        GameObject.FindGameObjectWithTag("OverlayCam").GetComponent<Camera>().fieldOfView = jumpChargeFOVValue;
        #endregion



        #region Arrow White Outline Pulsing VFX
        bool arrowPulsing = false;
        // Get the max jump charge of each arrow cell
        float cellMaxCharge = 1 / arrowsCharged.Length;

        // Copies JumpChargeStorage For Arrow VFX and for reducing to check amount of arrows that are filled
        float jumpChargeValue = jumpChargeValueStorage4ScreenVFX;

        // Pulse VFX when jumpCharge is fully charged ( or close enough )
        if (jumpChargeValue <= 0.995f)
        {
            playerUI.chargePulseVFX.Stop();
            arrowPulsing = false;
        }
        else
        {
            arrowPulsing = true;
            playerUI.chargePulseVFX.Play();
        }
        #endregion

        

        #region Arrow Cells
        // Changes color of all arrows based on interpolated color from jumpCharge value
        for (int i = 0; i < playerUI.arrows.Length; i++)
        {
            playerUI.arrows[i].fillImage.color = playerUI.interpolatedColor;
            
            // Moves the arrows to each others respective endpoints to keep distance between them the same even after scaling them
            if(i > 0)
                playerUI.arrows[i].transform.position = arrowEndPoints[i - 1].position;

            if (jumpChargeValue <= 0)
            {
                playerUI.arrows[i].value = 0;
                continue;
            }


            #region Play Arrow Impact VFX
            // Checks if total jumpCharge is less than the amount needed for 1 cell,
            // the total jumpCharge will reduce by 1 cells amount each loop to check which cell has not been filled
            if (jumpChargeValue > cellMaxCharge)
            {

                // if check to only run once when cell is first fully charged
                if (!arrowsCharged[i])
                {
                    arrowsCharged[i] = true;
                    // play arrow impact VFX
                    playerUI.arrowCellsChargedVFX[i].gameObject.SetActive(true);
                    playerUI.arrowCellsChargedVFX[i].Play();
                    playerUI.arrowCellsChargedVFX[i].startColor = playerUI.interpolatedColor;
                }
            }
            #endregion

            // Reduce totalJumpCharge by a cells amount to help check if the next arrow cell is filled
            float dividedJumpCharge = cellMaxCharge;
            jumpChargeValue -= cellMaxCharge;


            #region edge case handling to reset arrowsCharge to false after jumping
            if (jumpChargeValue <= 0)
            {
                dividedJumpCharge += jumpChargeValue;

                if (arrowsCharged[i])
                    arrowsCharged[i] = false;
            }
            #endregion

            dividedJumpCharge *= playerUI.arrows.Length;

            playerUI.arrows[i].value = dividedJumpCharge;

            float jumpChargeArrowScaleValue = (1 + ((dividedJumpCharge) * jumpChargeArrowScaleDiff)) * baseArrowScale;

            playerUI.arrows[i].GetComponent<RectTransform>().localScale = new Vector3(jumpChargeArrowScaleValue, 
                jumpChargeArrowScaleValue, jumpChargeArrowScaleValue);


        }
        #endregion



        #region Arrow scale Pulsing 

        float arrowScale = (1 + jumpChargeArrowScaleDiff)*(baseArrowScale);

        // Checks if all arrow cells are roughly filled up and fully charged
        if (arrowPulsing)
        {
            #region Resets and Initialise Variables and first run
            if (!arrowScalingStarted)
            {
                foreach (ImageProgressBar arrow in playerUI.arrows)
                {
                    arrow.GetComponent<PulsingScaleScript>().timeElapsed = 0;
                }
                    
                arrowScalingStarted = true;
            }
            #endregion

            #region Inilialize the actual scripts
            foreach (ImageProgressBar arrow in playerUI.arrows)
            {
                arrow.GetComponent<PulsingScaleScript>().initialScale = new Vector3(arrowScale, arrowScale, arrowScale);
                
                arrow.GetComponent<PulsingScaleScript>().hasStarted = true;
                arrow.GetComponent<PulsingScaleScript>().stoppingStarted = false;
            }
            #endregion

        }
        else
        {
            foreach (ImageProgressBar arrow in playerUI.arrows)
            {
                // Reset Scale to current arrows Scale if jump charge is more than 0 but not full charge
                if (jumpingPlayer.jumpCharge > 0)
                {
                    arrow.GetComponent<PulsingScaleScript>().initialScale = new Vector3(arrowScale, arrowScale, arrowScale); ;
                    arrow.GetComponent<PulsingScaleScript>().stoppingStarted = true;
                }
                // Resets Scale of arrows to its starting scale if jumpCharge is <= 0, as well as force stopping the pulsing script
                else
                {
                    arrow.GetComponent<PulsingScaleScript>().forceStop = true;
                    arrow.GetComponent<RectTransform>().localScale = new Vector3(baseArrowScale, baseArrowScale, baseArrowScale);
                }
                arrowScalingStarted = false;
            }
        }


        #endregion
    }

    



    public void CameraPositioning()
    {
        float currentY = jumpingPlayer.transform.position.y;

        // If player is below current platforms y position, if it isn't then move the player camera up to follow the player
        if (currentY < PlatformManager.instance.lastLandedPlatform.transform.position.y + platformHeightOffset) { return; }

        highestY = currentY;

        transform.position = new Vector3(transform.position.x, highestY + yOffset, transform.position.z);
    }
}
