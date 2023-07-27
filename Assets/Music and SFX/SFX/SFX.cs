using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip scoreSfx;
    public AudioClip landSfx;
    public AudioClip jumpSfx;
    public AudioClip stopwatchPickup;
    public AudioClip stopwatchOn;
    public AudioClip stopwatchEnd;
    public AudioClip shieldPickup;
    public AudioClip gettingHit;
    public AudioClip jumpVoice;
    public AudioClip hitSound;
    public AudioClip chargingSound;
    public AudioClip contiCharge;
    public static bool scoreSound;
    public static bool landSound;
    public static bool jumpSound;
    public static bool stopwatchPickSound;
    public static bool stopwatchPickOn;
    public static bool stopwatchPickEnd;
    public static bool shieldPick;
    public static bool hit;
    public static bool voiceJump;
    public static bool charging;
    public static bool contiCharging;

    public static float sfxVol;
    public float sfxVolume;

    private void Update()
    {
        audio.volume = sfxVolume / 100;

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
            audio.clip = jumpSfx;
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
            audio.PlayOneShot(hitSound);
            hit = false;
        }
        if (voiceJump == true)
        {
            sfxVol = sfxVolume;
            audio.clip = jumpVoice;
            sfxVolume = sfxVol;
            audio.PlayOneShot(jumpVoice);
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
