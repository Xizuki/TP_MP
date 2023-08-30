using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XizukiMethods.GameObjects;

public class PlatformManager : MonoBehaviour
{
    public Chicken chicken;
    public JumpingPlayerScript player;
    public List<PlatformScript> platforms;
    public static PlatformManager instance;
    public PlatformScript lastLandedPlatform;

    public bool playedFallingSound;

    public Score scoreScript;
    public ComboCount comboCountScript;

    public float chargeBarScoreMultiplyer;
    public float chargeBarFullScoreMultiplyer;

    // Very half ass way of doing it, should be done in code if have time
    public Transform platformDissappearingPoint;
    public Transform PlayerStatisFallPoint;

    private void Awake()
    {
        XizukiMethods.GameObjects.Xi_Helper_GameObjects.MonoInitialization<PlatformManager>(ref instance, this);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
        CanvasScript canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();

        scoreScript = canvasScript.scoreScript;
        comboCountScript = canvasScript.comboScript;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetLastLandedPlatform(PlatformScript collidedPlatform)
    {

        if (lastLandedPlatform == collidedPlatform) { return; }

        if (collidedPlatform.transform.position.y < lastLandedPlatform.transform.position.y) { return; }

        float oldPlatformY = lastLandedPlatform.transform.position.y;

        lastLandedPlatform = collidedPlatform;

        chicken.startingPlatform = collidedPlatform.gameObject;


        float platformYDistance = lastLandedPlatform.transform.position.y - oldPlatformY;


        float scoreMultiplied = player.jumpChargePrev * chargeBarScoreMultiplyer;
        if (player.jumpChargePrev >= 1) { scoreMultiplied *= chargeBarFullScoreMultiplyer; }

        // ADD VISUAL EFFECT TO ADD SCORE in FUTURE
        scoreScript.AddScore(scoreMultiplied, platformYDistance);



        AddCombo();
    }

    public void AddCombo()
    {
        ComboCount.combo += 1;
        ComboCount.hit = true;
        SFX.scoreSound = true;
        SFX.landSound = true;
        Tweening.comboUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Only Run this Script when new platforms are generated for optimization
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject GO in GOs)
        {
            platforms.Add(GO.GetComponent<PlatformScript>());
        }

        List<PlatformScript> platformsToRemove = new List<PlatformScript>();

        foreach (PlatformScript platform in platforms)
        {
            if (platform == lastLandedPlatform) { continue; }

            if (platform.transform.position.y >= lastLandedPlatform.transform.position.y) { continue; }

            if (platform.transform.position.y < platformDissappearingPoint.transform.position.y)
            {
                Destroy(platform.gameObject);
            }
            //else if (platform.transform.position.y < PlayerStatisFallPoint.transform.position.y)
            //{
            //    platform.GetComponent<BoxCollider>().enabled = false;
            //}
        }

        foreach (PlatformScript platform in platformsToRemove)
        {
            platforms.Remove(platform);
        }

        //very inefficient, the fix in this should be done with the one on top
        platforms.Clear();

        if (player.transform.position.y < PlayerStatisFallPoint.transform.position.y - 1f)
        {

            player.playerUI.normalShiba.gameObject.SetActive(false);
            player.playerUI.stunShiba.gameObject.SetActive(true);

            player.shibaCollider.enabled = true;
            chicken.playerDowned = true;
            if (playedFallingSound == false)
            {
                SFX.fallingVoiceCheck = true;
                playedFallingSound = true;
            }
            chicken.AbovePlatformCheck();
        }
        else if ((player.transform.position.y > PlayerStatisFallPoint.transform.position.y - 1f))
        {
            playedFallingSound = false;
            SFX.fallingVoiceCheck = false;
        }
    }
}
