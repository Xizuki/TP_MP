using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public ParticleSystem auraShield;

    public ParticleSystem shieldPickup;

    public GameObject shieldVfx;
    public GameObject shieldIconVfx;
    public GameObject shieldBGVFX;

    public Image shieldSliderFill;


    public Image stopwatchSliderFill;

    public GameObject stopwatchVfx;
    public GameObject stopwatchFilter;

    public GameObject stopwatchEndVfx;
    public GameObject stopwatchIconVfx;
    public AudioSource stopwatchEndSfx;
    public AudioClip stopwatchEnd;

    public Animator snowWeatherVfx;

    public Image jumpChargeScreenVFX;

    public Image normalShiba;
    public Image stunShiba;


    public Score scoreScript;
    public ComboCount comboScript;

    public GameObject crownProfile;

    public EndScene endScene;

    public GameTimer gameTimer;


    public Pause pause;

    public Pause intervalPause;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GetComponentInChildren<Score>();
        comboScript = GetComponentInChildren<ComboCount>();
        gameTimer = GetComponentInChildren<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
