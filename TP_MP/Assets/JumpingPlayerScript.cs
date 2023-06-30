using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpingPlayerUIScript))]
public class JumpingPlayerScript : MonoBehaviour
{
    public JumpingPlayerUIScript playerUI;
    public Rigidbody rb;

    public float jumpCharge;
    public float jumpChargeMax;
    public float jumpChargeSpeed;
    public Vector2 jumpAngleVector;
    public float rbJumpStrength;

    public bool isGrounded;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerUI = GetComponent<JumpingPlayerUIScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis("Horizontal"));

        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown((KeyCode)(KeyCode.JoystickButton0 + i)))
            {
                Debug.Log("JoystickButton" + i + " pressed");
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerUI.jumpingVectorIndicator.transform.eulerAngles += new Vector3(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(playerUI.jumpingVectorIndicator.transform.up * rbJumpStrength, ForceMode.Impulse);
        }
    }
}
