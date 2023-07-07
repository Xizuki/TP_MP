using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip scoreSfx;
    public AudioClip landSfx;
    public AudioClip jumpSfx;
    public static bool scoreSound;
    public static bool landSound;
    public static bool jumpSound;

    public static float sfxVol;
    public float sfxVolume;

    private void Update()
    {
        if (scoreSound == true)
        {
            sfxVol = sfxVolume;
            audio.clip = scoreSfx;
            sfxVolume = sfxVol;
            audio.PlayOneShot(scoreSfx);
            scoreSound = false;

            print("Score SFX");
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
    }
}
