using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerScript : MonoBehaviour
{
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * rbJumpStrength, ForceMode.Impulse);
        }
    }
}
