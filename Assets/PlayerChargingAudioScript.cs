using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingAudioScript : MonoBehaviour
{
    public AudioClip clip1;
    public AudioSource audioSource;
    public JumpingPlayerScript jumpingPlayerScript;

    public AudioClip[] pitches;
    public AudioClip constantAudio;
    public AudioClip constantAudioDeep;

    public int audioVersions;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        jumpingPlayerScript = GetComponent<JumpingPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioVersions == 0)
        {
            audioSource.pitch = 1;

            if (audioSource.isPlaying) return;
            if (!jumpingPlayerScript.isCharging) return;

            audioSource.PlayOneShot(audioSource.clip);
        }
        else if (audioVersions == 1)
        {
            audioSource.pitch = 1;

            if (audioSource.isPlaying) return;
            if (!jumpingPlayerScript.isCharging) return;


            int i = (int)((jumpingPlayerScript.jumpCharge * 3));
            audioSource.PlayOneShot(pitches[i]);
        }
        else if (audioVersions == 2)
        {
            audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);

            if (audioSource.isPlaying) return;
            if (!jumpingPlayerScript.isCharging) return;

            audioSource.PlayOneShot(audioSource.clip);
        }
        else if (audioVersions == 3)
        {
            audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);

            //if (!pitchedVersion) return;
            if (audioSource.isPlaying) return;
            if (!jumpingPlayerScript.isCharging) return;


            int i = (int)((jumpingPlayerScript.jumpCharge * 3));
            audioSource.PlayOneShot(pitches[i]);
        }



        else if (audioVersions == 4)
        {
            audioSource.pitch = 1;
            audioSource.clip = constantAudio;

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.isPlaying)
                audioSource.Pause();
        }
        else if (audioVersions == 5)
        {
            audioSource.pitch = 1;
            audioSource.clip = constantAudioDeep;

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.isPlaying)
                audioSource.Pause();
        }
        else if (audioVersions == 6)
        {
            audioSource.pitch = 0.5f+(jumpingPlayerScript.jumpCharge/2);
            audioSource.clip = constantAudio;

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying) 
                audioSource.Play();
            else if(!jumpingPlayerScript.isCharging && audioSource.isPlaying)
                audioSource.Pause();
        }
        else if (audioVersions == 7)
        {
            audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);
            audioSource.clip = constantAudioDeep;

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.isPlaying)
                audioSource.Pause();
        }
    }

    public void MonoToneAudio()
    {
        //if (pitchedVersion) return;
        if (audioSource.isPlaying) return;
        if (!jumpingPlayerScript.isCharging) return;

        audioSource.PlayOneShot(audioSource.clip);
    }
}
