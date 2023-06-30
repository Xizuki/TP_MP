using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(JumpingPlayerScript))]
public class JumpingPlayerUIScript : MonoBehaviour
{
    public float jumpVectorRotationSpeed;
    public JumpingPlayerScript player;
    public GameObject jumpingVectorIndicator;
    public Slider jumpChargeSlider;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();
    }
    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
