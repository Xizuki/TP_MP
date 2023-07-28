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
    //public ParticleSystem auraShield;
    public Image sliderFill;
    public float delay = 0;
    float timer = 10f;
    public override void Effect()
    {
        base.Effect();
    }
    private void Update()
    {
        // should make it so it only runs once on activation for optimization but im lazy rn
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        cactusEnemies = Xi_Helper_GameObjects.FilterOutWithScript<CactusEnemy>(ref enemies);
        mushroomEnemies = Xi_Helper_GameObjects.FilterOutWithScript<MushroomEnemy>(ref enemies);


        BulletMove[] bullets = GameObject.FindObjectsByType<BulletMove>(FindObjectsSortMode.None);

        if (isActivated)
        {

            foreach (CactusEnemy cactus in cactusEnemies)
            {
                cactus.cactusShoot.shootDelayTimer = cactus.cactusShoot.baseShootDelayTimer * slowMultiplyer;
            }
            foreach (MushroomEnemy mushroom in mushroomEnemies)
            {
                mushroom.patrolCheck.speed = mushroom.patrolCheck.baseSpeed / slowMultiplyer;
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

        }
    }
}
