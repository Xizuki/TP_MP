using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XizukiMethods.GameObjects;

public class StopWatchPowerUp : PowerUpScript
{
    public float slowMultiplyer;
    public CactusEnemy[] cactusEnemies;
    public MushroomEnemy[] mushroomEnemies;
    public BottomCheck[] turtleEnemies;
    public ChestEnemy[] chestEnemies;
    public EyeEnemy[] eyeEnemies;
    public Animator[] cactusAnimator;
    public Animator[] eyeAnimator;
    public Animator[] chestAnimator;
    public Animator[] turtleAnimator;
    public Animator[] mushroomAnimator;
    //public ParticleSystem auraShield;
    public Image sliderFill;
    public float delay = 0;
    public float timer;

    public GameObject stopwatchFilter;
    public GameObject stopwatchEndVfx;
    public GameObject stopwatchIconVfx;
    public AudioSource stopwatchEndSfx;
    public AudioClip stopwatchEnd;
    public bool stopwatchHasEnd;
    public float snowWeatherSpd;
    public Animator snowWeatherVfx;

    public void Start()
    {
        CanvasScript canvasScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();
        sliderFill = canvasScript.stopwatchSliderFill;


        stopwatchFilter = canvasScript.stopwatchFilter;
        stopwatchEndVfx = canvasScript.stopwatchEndVfx;
        stopwatchIconVfx = canvasScript.stopwatchIconVfx;
        stopwatchEndSfx = canvasScript.stopwatchEndSfx;
        stopwatchEnd = canvasScript.stopwatchEnd;

        stopwatchHasEnd = true;
        snowWeatherVfx.speed = 0.75f;
        stopwatchIconVfx.SetActive(false);
    }
    public override void Effect()
    {
        base.Effect();
    }

    private void Update()
    {
        // should make it so it only runs once on activation for optimization but im lazy rn
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // FilterOutWithScripts returns an array with the defined class while removing it from the referenced array
        cactusEnemies = Xi_Helper_GameObjects.FilterOutWithScript<CactusEnemy>(ref enemies);
        mushroomEnemies = Xi_Helper_GameObjects.FilterOutWithScript<MushroomEnemy>(ref enemies);
        chestEnemies = Xi_Helper_GameObjects.FilterOutWithScript<ChestEnemy>(ref enemies);
        turtleEnemies = Xi_Helper_GameObjects.FilterOutWithScript<BottomCheck>(ref enemies);
        eyeEnemies = Xi_Helper_GameObjects.FilterOutWithScript<EyeEnemy>(ref enemies);

        // Get Animator of different enemies
        cactusAnimator = new Animator[cactusEnemies.Length];
        mushroomAnimator = new Animator[mushroomEnemies.Length];
        chestAnimator = new Animator[chestEnemies.Length];
        turtleAnimator = new Animator[turtleEnemies.Length];
        eyeAnimator = new Animator[eyeEnemies.Length];
        for (int i =0; i < cactusEnemies.Length;i++)
        {
            cactusAnimator[i] = cactusEnemies[i].GetComponent<Animator>();
        }
        for (int i = 0; i < mushroomEnemies.Length; i++)
        {
            mushroomAnimator[i] = mushroomEnemies[i].GetComponent<Animator>();
        }
        for (int i = 0; i < chestEnemies.Length; i++)
        {
            chestAnimator[i] = chestEnemies[i].GetComponent<Animator>();
        }
        for (int i = 0; i < turtleEnemies.Length; i++)
        {
            turtleAnimator[i] = turtleEnemies[i].GetComponent<Animator>();
        }
        for (int i = 0; i < eyeEnemies.Length; i++)
        {
            eyeAnimator[i] = eyeEnemies[i].GetComponent<Animator>();
        }


        BulletMove[] bullets = GameObject.FindObjectsByType<BulletMove>(FindObjectsSortMode.None);

        if (sliderFill.fillAmount == 0)
        {
            if (stopwatchHasEnd == false)
            {
                StartCoroutine(StopwatchEnd());
            }
        }
        else if (sliderFill.fillAmount >= 0.1)
        {
            stopwatchHasEnd = false;
            stopwatchEndVfx.SetActive(false);
            stopwatchFilter.SetActive(true);
            stopwatchIconVfx.SetActive(true);
            //snowWeatherVfx.speed = 0.5f;
            
        }


        if (isActivated)
        {
            for (int i = 0; i < cactusEnemies.Length; i++)
            {
                cactusAnimator[i].speed = 0.5f;
            }
            for (int i = 0; i < mushroomEnemies.Length; i++)
            {
                mushroomAnimator[i].speed = 0.5f;
            }
            for (int i = 0; i < chestEnemies.Length; i++)
            {
                chestAnimator[i].speed = 0.5f;
            }
            for (int i = 0; i < turtleEnemies.Length; i++)
            {
                turtleAnimator[i].speed = 0.5f;
            }
            for (int i = 0; i < eyeEnemies.Length; i++)
            {
                eyeAnimator[i].speed = 0.5f;
            }

            foreach (BulletMove bullet in bullets)
            {
                bullet.speed = bullet.baseSpeed / slowMultiplyer;
            }
            sliderFill.fillAmount = 1;
            sliderFill.fillAmount = timer / 10;
            timer -= Time.deltaTime;
            if (timer < delay)
            {
                isActivated = false;
                timer = 10f;
                sliderFill.fillAmount = 0;
                //auraShield.Stop();
            }
        }
        else
        {   
            foreach (CactusEnemy cactus in cactusEnemies)
            {
                cactus.cactusShoot.shootDelayTimer = cactus.cactusShoot.baseShootDelayTimer;
            }
            foreach (MushroomEnemy mushroom in mushroomEnemies)
            {
                mushroom.patrolCheck.speed = mushroom.patrolCheck.baseSpeed;
            }
            foreach (BulletMove bullet in bullets)
            {
                bullet.speed = bullet.baseSpeed;
            }

            for (int i = 0; i < cactusEnemies.Length; i++)
            {
                cactusAnimator[i].speed = 1.5f;
            }
            for (int i = 0; i < mushroomEnemies.Length; i++)
            {
                mushroomAnimator[i].speed = 1.5f;
            }
            for (int i = 0; i < chestEnemies.Length; i++)
            {
                chestAnimator[i].speed = 1.5f;
            }
            for (int i = 0; i < turtleEnemies.Length; i++)
            {
                turtleAnimator[i].speed = 1.5f;
            }
            for (int i = 0; i < eyeEnemies.Length; i++)
            {
                eyeAnimator[i].speed = 1.5f;
            }
        }

        IEnumerator StopwatchEnd()
        {
            stopwatchHasEnd = true;
            stopwatchEndVfx.SetActive(true);
            yield return new WaitForSeconds(1.75f);
            snowWeatherVfx.speed = 0.75f;
            stopwatchEndVfx.SetActive(false);
            stopwatchIconVfx.SetActive(false);
            stopwatchFilter.SetActive(false);
        }
    }
}
