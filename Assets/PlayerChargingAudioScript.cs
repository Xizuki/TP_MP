using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingAudioScript : MonoBehaviour
{
    //public AudioClip clip1;
    public AudioSource audioSource;
    public JumpingPlayerScript jumpingPlayerScript;

    //public AudioClip[] pitches;
    //public AudioClip constantAudio;
    //public AudioClip constantAudioDeep;


    public float audioTime;

    public AudioClip[] constantAudios;
    public int audioVersions;

    DictionaryVolumeSettings dictionary;
    // Start is called before the first frame update
    void Start()
    {
        dictionary = FindObjectOfType<DictionaryVolumeSettings>();

        audioSource = GetComponent<AudioSource>();
        jumpingPlayerScript = GetComponent<JumpingPlayerScript>();
    }
    float optionsVolumeMultiplier;

    // Update is called once per frame
    void Update()
    {
        audioTime = audioSource.time;

        optionsVolumeMultiplier = dictionary.SoundSettings["ChargingSound"]/10;
        //print("optionsVolumeMultiplier = " + optionsVolumeMultiplier);

        if (Time.timeScale == 0) { audioSource.Stop(); return; }

        if (Input.GetKeyUp(KeyCode.Alpha1))
            audioVersions = 0;
        if (Input.GetKeyUp(KeyCode.Alpha2))
            audioVersions = 1;
        if (Input.GetKeyUp(KeyCode.Alpha3))
            audioVersions = 2;


        if (jumpingPlayerScript.isCharging && jumpingPlayerScript.isGrounded)
        {
            audioSource.volume = 1* optionsVolumeMultiplier;
        }
        else if (!jumpingPlayerScript.isCharging && audioSource.volume > 0 && jumpingPlayerScript.isGrounded)
        {
            audioSource.volume -= 2.5f * Time.deltaTime* optionsVolumeMultiplier;
        }


        if (audioVersions ==0)
        {
            audioSource.clip = constantAudios[audioVersions];

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying && jumpingPlayerScript.isGrounded)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.volume <= 0 && !jumpingPlayerScript.isGrounded)
                audioSource.Pause();
        }

        if (audioVersions == 1)
        {
            audioSource.clip = constantAudios[audioVersions];

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.volume <= 0)
                audioSource.Pause();
        }

        if (audioVersions == 2)
        {
            audioSource.clip = constantAudios[audioVersions];

            if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
                audioSource.Play();
            else if (!jumpingPlayerScript.isCharging && audioSource.volume <= 0)
                audioSource.Pause();
        }

        //if (!jumpingPlayerScript.isCharging)
        //{
        //    audioSource.volume = 0;
        //}

        //if (audioVersions == 0)
        //{
        //    audioSource.pitch = 1;

        //    if (audioSource.isPlaying) return;
        //    if (!jumpingPlayerScript.isCharging) return;

        //    audioSource.PlayOneShot(audioSource.clip);
        //}
        //else if (audioVersions == 1)
        //{
        //    audioSource.pitch = 1;

        //    if (audioSource.isPlaying) return;
        //    if (!jumpingPlayerScript.isCharging) return;


        //    int i = (int)((jumpingPlayerScript.jumpCharge * 3));
        //    audioSource.PlayOneShot(pitches[i]);
        //}
        //else if (audioVersions == 2)
        //{
        //    audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);

        //    if (audioSource.isPlaying) return;
        //    if (!jumpingPlayerScript.isCharging) return;

        //    audioSource.PlayOneShot(audioSource.clip);
        //}
        //else if (audioVersions == 3)
        //{
        //    audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);

        //    //if (!pitchedVersion) return;
        //    if (audioSource.isPlaying) return;
        //    if (!jumpingPlayerScript.isCharging) return;


        //    int i = (int)((jumpingPlayerScript.jumpCharge * 3));
        //    audioSource.PlayOneShot(pitches[i]);
        //}



        //else if (audioVersions == 4)
        //{
        //    audioSource.pitch = 1;
        //    audioSource.clip = constantAudio;

        //    if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
        //        audioSource.Play();
        //    else if (!jumpingPlayerScript.isCharging && audioSource.volume <= 0)
        //        audioSource.Pause();
        //}
        //else if (audioVersions == 5)
        //{
        //    audioSource.pitch = 1;
        //    audioSource.clip = constantAudioDeep;

        //    if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
        //        audioSource.Play();
        //    else if (!jumpingPlayerScript.isCharging && audioSource.isPlaying)
        //        audioSource.Pause();
        //}
        //else if (audioVersions == 6)
        //{
        //    audioSource.pitch = 0.5f+(jumpingPlayerScript.jumpCharge/2);
        //    audioSource.clip = constantAudio;

        //    if (jumpingPlayerScript.isCharging && !audioSource.isPlaying) 
        //        audioSource.Play();
        //    else if(!jumpingPlayerScript.isCharging && audioSource.isPlaying)
        //        audioSource.Pause();
        //}
        //else if (audioVersions == 7)
        //{
        //    audioSource.pitch = 0.5f + (jumpingPlayerScript.jumpCharge / 2);
        //    audioSource.clip = constantAudioDeep;

        //    if (jumpingPlayerScript.isCharging && !audioSource.isPlaying)
        //        audioSource.Play();
        //    else if (!jumpingPlayerScript.isCharging && audioSource.isPlaying)
        //        audioSource.Pause();
        //}
    }

    public void MonoToneAudio()
    {
        //if (pitchedVersion) return;
        if (audioSource.isPlaying) return;
        if (!jumpingPlayerScript.isCharging) return;

        audioSource.PlayOneShot(audioSource.clip);
    }
}
