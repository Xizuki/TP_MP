using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource audio2;
    public AudioClip scoreSfx;
    public AudioClip landSfx;
    public AudioClip jumpSfx;
    public AudioClip stopwatchPickup;
    public AudioClip stopwatchOn;
    public AudioClip stopwatchEnd;
    public AudioClip shieldPickup;
    public AudioClip gettingHit;
    public AudioClip jumpVoice;
    public AudioClip fallingVoice;
    public AudioClip chargingSound;
    public AudioClip contiCharge;
    public GameObject performance;
    public static bool scoreSound;
    public static bool landSound;
    public static bool jumpSound;
    public static bool stopwatchPickSound;
    public static bool stopwatchPickOn;
    public static bool stopwatchPickEnd;
    public static bool shieldPick;
    public static bool hit;
    public static bool fallingVoiceCheck;
    public static bool voiceJump;
    public static bool charging;
    public static bool contiCharging;
    public static bool performanceCharge;

    public static float sfxVol;
    public static float sfxPerformanceVol;
    public float sfxVolume;
    public float sfxVolume2;

    IEnumerator PerformanceCharging()
    {
        //performance.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //if (performanceCharge == true)
        //{
        //    performance.SetActive(true);
        //}
        //else if (performanceCharge == false)
        //{
        //    performance.SetActive(false);
        //}
    }
    
    private void Update()
    {
        //audio.volume = sfxVolume / 100;
        //audio2.volume = sfxPerformanceVol / 100;

        if (performanceCharge == true)
        {
            sfxPerformanceVol = sfxVolume2;
            sfxVolume2 = sfxPerformanceVol;
            StartCoroutine(PerformanceCharging());
            //audio.PlayOneShot(performance);
        }
        /*if (performanceCharge == false)
        {
            performance.SetActive(false);
        }*/
        if (scoreSound == true)
        {
            sfxVol = sfxVolume;
            audio.clip = scoreSfx;
            sfxVolume = sfxVol;
            audio.PlayOneShot(scoreSfx);
            scoreSound = false;
        }
        if (landSound == true)
        {
            sfxVol = sfxVolume;
            audio.clip = landSfx;
            sfxVolume = sfxVol;
            audio.PlayOneShot(landSfx);
            if (Random.Range(1,3) == 2)
            {
                audio.PlayOneShot(jumpVoice);
            }
            landSound = false;
        }
        if (jumpSound == true)
        {
            sfxVol = sfxVolume;
            audio.clip = jumpSfx;
            sfxVolume = sfxVol;
            audio.PlayOneShot(jumpSfx);
            jumpSound = false;

        }
        if (stopwatchPickOn == true)
        {
            sfxVol = sfxVolume;
            audio.clip = stopwatchOn;
            sfxVolume = sfxVol;
            audio.PlayOneShot(stopwatchOn);
            stopwatchPickOn = false;

        }
        if (stopwatchPickEnd == true)
        {
            sfxVol = sfxVolume;
            audio.clip = stopwatchEnd;
            sfxVolume = sfxVol;
            audio.PlayOneShot(stopwatchEnd);
            stopwatchPickEnd = false;
        }
        if (stopwatchPickSound == true)
        {
            sfxVol = sfxVolume;
            audio.clip = stopwatchPickup;
            sfxVolume = sfxVol;
            audio.PlayOneShot(stopwatchPickup);
            stopwatchPickSound = false;
        }
        if (shieldPick == true)
        {
            sfxVol = sfxVolume;
            audio.clip = shieldPickup;
            sfxVolume = sfxVol;
            audio.PlayOneShot(shieldPickup);
            shieldPick = false;
        }
        if (hit == true)
        {
            sfxVol = sfxVolume;
            audio.clip = gettingHit;
            sfxVolume = sfxVol;
            audio.PlayOneShot(gettingHit);
            //audio.PlayOneShot(fallingVoice);
            hit = false;
        }
        if (fallingVoiceCheck == true)
        {
            sfxVol = sfxVolume;
            audio.clip = fallingVoice;
            sfxVolume = sfxVol;
            audio.PlayOneShot(fallingVoice);
            fallingVoiceCheck = false;
        }
        if (voiceJump == true)
        {
            sfxVol = sfxVolume;
            audio.clip = jumpVoice;
            sfxVolume = sfxVol;
            if (Random.Range(1, 5) >= 3)
            {
                audio.PlayOneShot(jumpVoice);
            }
            voiceJump = false;
        }
        if (charging == true)
        {
            sfxVol = sfxVolume;
            audio.clip = chargingSound;
            sfxVolume = sfxVol;
            audio.PlayOneShot(chargingSound);
            charging = false;
        }
        if (contiCharging == true)
        {
            sfxVol = sfxVolume;
            audio.clip = contiCharge;
            sfxVolume = sfxVol;
            audio.PlayOneShot(contiCharge);
            contiCharging = false;
        }

    }
}
