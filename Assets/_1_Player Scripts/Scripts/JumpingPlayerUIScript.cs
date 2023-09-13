using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Nyp.Razor.Spectrum;
using Unity.VisualScripting;

[RequireComponent(typeof(JumpingPlayerScript))]
public class JumpingPlayerUIScript : MonoBehaviour
{
    public float jumpingVectorAngleLimit;
    public float jumpVectorRotationSpeed;
    public JumpingPlayerScript player;
    public GameObject jumpingVectorIndicator;
    public ImageProgressBar jumpChargeArrow;

    public Transform playerHeadTransform;
    public Transform jumpingVectorIndicatorEndPoint;
    public float jumpingVectorEndPointYMaxDistance;
    public float playerHeadLookUpAngleLimit;
    private Outline outlineScript;


    public Color startingColor;
    public Color endColor;
    public Color interpolatedColor;

    public ParticleSystem chargePulseVFX;

    public Vector3 faceForward;

    public Image normalShiba;
    public Image stunShiba;

    public LineRenderer lineRenderer;


    public ImageProgressBar[] arrows;
    public ParticleSystem[] arrowCellsChargedVFX;
    // Start is called before the first frame update
    void Awake()
    {
        CanvasScript canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();   
        normalShiba = canvasScript.normalShiba; stunShiba = canvasScript.stunShiba;

        player = GetComponent<JumpingPlayerScript>();
        outlineScript = GetComponentInChildren<Outline>();
        chargePulseVFX = GetComponentInChildren<ParticleSystem>();
        lineRenderer = GetComponentInChildren<LineRenderer>();


        // Assign faceForward as the starting head angle
        faceForward = playerHeadTransform.transform.eulerAngles;
    }
    public void Start()
    {
        jumpingVectorEndPointYMaxDistance = (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y);
    }


    // Interpolate Colors from 0 to 1 based on 2 colors
    public Color SetColor(float jumpCharge)
    {
        Gradient colorGradient = new Gradient();
        colorGradient.SetKeys(
            new GradientColorKey[] { 
                new GradientColorKey(Color.red, 0.3f), 
                new GradientColorKey(Color.yellow, 0.65f),
                new GradientColorKey(Color.green, 1) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, 1), 
                new GradientAlphaKey(1, 1)} );


        // Calculate the color for the current temperature
        Color color = colorGradient.Evaluate(jumpCharge);

        return color;
    }

    private void FixedUpdate()
    {
        interpolatedColor = SetColor(player.jumpCharge);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Check if player has recently inputed in the last few seconds
        if (player.faceFront)
        {
            // if true, player looks head on at the camera
            playerHeadTransform.eulerAngles = faceForward;
        }
        else if (!player.faceFront && player.isGrounded)
        {
            // else, player looks up at where the arrow is

            // Take the percentage ratio between the difference of the empty position on
            // the end of the arrow and the players head and the max magnitude distance 
            float currentEndPointYDistanceRatio = 
                    (jumpingVectorIndicatorEndPoint.position.y - playerHeadTransform.position.y) 
                    / jumpingVectorEndPointYMaxDistance;

            playerHeadTransform.localEulerAngles = 
                    new Vector3(0, playerHeadTransform.localEulerAngles.y, -playerHeadLookUpAngleLimit 
                    * currentEndPointYDistanceRatio);
        }
    }

   


}