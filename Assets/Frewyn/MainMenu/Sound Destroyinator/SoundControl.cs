using Menu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundControl : MonoBehaviour
{
    private Dictionary_GameplaySettings dictionary;

    private DictionaryVolumeSettings soundDictionary;

    private void Awake()
    {
        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();

        soundDictionary = FindObjectOfType<DictionaryVolumeSettings>();
    }


    void Start()
    {
        AdjustAll();
    

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AdjustAll()
    {
        MuteAll();

       // AdjustWithMasterVolume();

        AdjustBGVolume();

        AdjustChargingVolume();

        AdjustSFXVolume();

        AdjustCrownVolume();

        AdjustAmbient();
    }

    void AdjustWithMasterVolume()
    {
        AudioSource[] objectsToAdjust = FindObjectsOfType<AudioSource>();

        foreach (AudioSource objects in objectsToAdjust)
        {
            objects.volume = soundDictionary.SoundSettings["Volume"] * 0.1f;
        }


    }

    void MuteAll()
    {
        if (dictionary.GameplaySettings["Mute"] == Difficulty.On)
        {
            AudioSource[] objectToDisable = FindObjectsOfType<AudioSource>(); //Finds all objects with audio source

            foreach (AudioSource objects in objectToDisable)
            {
                objects.mute = true; //Mute them
            }
        }

        else if (dictionary.GameplaySettings["Mute"] == Difficulty.Off)
        {
            AudioSource[] objectToEnable = FindObjectsOfType<AudioSource>(); //Finds all object with audio source

            foreach (AudioSource objects in objectToEnable)
            {
                objects.mute = false; //Unmute them
            }
        }
    }

    void AdjustBGVolume()
    {

        //Music audioSourceToAdjust = FindObjectOfType<Music>();//Find the script that handles BG Music

        ////Adjust the audio source volume by multiplying it with the BG Music value found in the settings/dictionary
        //audioSourceToAdjust.music.volume *= soundDictionary.SoundSettings["Volume"] *soundDictionary.SoundSettings["BGMusic"] * 0.1f;


        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("BGMusic");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["BGMusic"]*0.1f ;



        }
    }

        void AdjustChargingVolume()
    {

        //AudioSource audioSourceToAdjust = GameObject.FindGameObjectWithTag("ChargingSound").GetComponent<AudioSource>();

        //audioSourceToAdjust.volume *= soundDictionary.SoundSettings["Volume"] * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;




        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("ChargingSound");


        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;



        }
    }


    void AdjustSFXVolume()
    {
        //AudioSource audioSourceToAdjust = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        //Debug.Log("Original Volume: " + audioSourceToAdjust.volume);

        //Debug.Log("Volume Multiplier: " + soundDictionary.SoundSettings["SFX"]);

        //audioSourceToAdjust.volume *= soundDictionary.SoundSettings["Volume"] * soundDictionary.SoundSettings["SFX"]*0.1f;
        //Debug.Log("New Volume: " + audioSourceToAdjust.volume);


        //GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("SFX");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        //foreach (AudioSource audioSource in ambientAudioSources)
        //{
        //    audioSource.volume *=soundDictionary.SoundSettings["SFX"] * 0.1f;
        //}

        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("SFX");

        


        foreach (GameObject gameObject in ambientObjects)
        {
            Debug.Log("GameObject: " +gameObject.name);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["SFX"] * 0.1f;



        }

    }


    void AdjustCrownVolume()
    {
        //AudioSource audioSourceToAdjust = GameObject.FindGameObjectWithTag("Crown").GetComponent<AudioSource>();

        //audioSourceToAdjust.volume *= soundDictionary.SoundSettings["Volume"] * soundDictionary.SoundSettings["Crown"] * 0.1f;

        //GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Crown");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        //foreach (AudioSource audioSource in ambientAudioSources)
        //{
        //    audioSource.volume *=soundDictionary.SoundSettings["Crown"] * 0.1f;
        //}

        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Crown");


        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["Crown"] * 0.1f;



        }
    }

    void AdjustAmbient()
    {

        //GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Ambient");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        //foreach (AudioSource audioSource in ambientAudioSources)
        //{
        //    audioSource.volume *= soundDictionary.SoundSettings["Ambient"] * 0.1f;
        //}

        //Debug.Log("Ambient value " + soundDictionary.SoundSettings["Ambient"]);
        //Debug.Log("BG value " + soundDictionary.SoundSettings["BGMusic"]);

        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Ambient");


        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"]*0.1f * soundDictionary.SoundSettings["Ambient"] * 0.1f;



        }






    }
}
