using Menu;
using Nyp.Razor.Spectrum;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{
    private Dictionary_GameplaySettings dictionary;

    private DictionaryVolumeSettings soundDictionary;

    [SerializeField]
    private AudioSource chargingSFX;

    [SerializeField]
    private AudioSource[] menuButtonSFX;

    private void Awake()
    {
        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();

        soundDictionary = FindObjectOfType<DictionaryVolumeSettings>();

        SceneManager.sceneLoaded += OnSceneLoaded;


    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex <= 1) 
        {
            AdjustBGVolume(1);
            AdjustAmbient(1);
        }
        else
        {
            AdjustAll();
        }
    }

    void Start()
    {
        AdjustAll();
    

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        { return; }

        chargingSFX = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();    
    }

    public float bgVolumeCache;
    public float ambientVolumeCache;

    public void AdjustAll()
    {
        if (GameObject.FindObjectOfType<CanvasScript>().gameTimer.gameEnded) return;

        MuteAll();

       // AdjustWithMasterVolume();

        AdjustBGVolume();

        AdjustChargingVolume();

        AdjustSFXVolume();

        AdjustCrownVolume();

        AdjustAmbient();


        bgVolumeCache = soundDictionary.SoundSettings["BGMusic"];
        ambientVolumeCache = soundDictionary.SoundSettings["Ambient"];
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
                Debug.Log("To mute: " + objects);
                objects.mute = true; //Mute them
            }

            if (chargingSFX != null)
                chargingSFX.mute = true;
        }

        else if (dictionary.GameplaySettings["Mute"] == Difficulty.Off)
        {
            AudioSource[] objectToEnable = FindObjectsOfType<AudioSource>(); //Finds all object with audio source

            foreach (AudioSource objects in objectToEnable)
            {
                objects.mute = false; //Unmute them
            }

            if (chargingSFX != null)
                chargingSFX.mute = false;
        }
    }

    void AdjustBGVolume()
    {

        if (SceneManager.GetActiveScene().buildIndex <= 1) return;
        
       Music audioSourceToAdjust = FindObjectOfType<Music>();//Find the script that handles BG Music

        //Adjust the audio source volume by multiplying it with the BG Music value found in the settings/dictionary
        if (audioSourceToAdjust != null)
        {
            audioSourceToAdjust.music.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["BGMusic"] * 0.1f;
        }
    


        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("BGMusic");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["BGMusic"] * 0.1f;



        }
    }


    public void AdjustBGVolume(int overrideVolume)
    {

        Music audioSourceToAdjust = FindObjectOfType<Music>();//Find the script that handles BG Music

        //Adjust the audio source volume by multiplying it with the BG Music value found in the settings/dictionary
        if (audioSourceToAdjust != null)
        {
            audioSourceToAdjust.music.volume = overrideVolume;
        }



        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("BGMusic");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = overrideVolume;



        }
    }

    void AdjustChargingVolume()
    {

        //AudioSource audioSourceToAdjust = GameObject.FindGameObjectWithTag("ChargingSound").GetComponent<AudioSource>();

        //audioSourceToAdjust.volume *= soundDictionary.SoundSettings["Volume"] * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;

        if(chargingSFX!=null)
        chargingSFX.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;

        Debug.Log("Charging adjusted " + soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f);




        //GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("ChargingSound");


        //foreach (GameObject gameObject in ambientObjects)
        //{
        //    AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        //    audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;



        //}
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

        if (menuButtonSFX!=null) //Used specifcally for menu SFX, != checks for if this is being called in menu, if not ignore this
        {
            foreach (AudioSource audioSource in menuButtonSFX)
            {
         

                audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["SFX"] * 0.1f;



            }
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
                if (SceneManager.GetActiveScene().buildIndex <= 1) return;

        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Ambient");


        foreach (GameObject gameObject in ambientObjects)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"]*0.1f * soundDictionary.SoundSettings["Ambient"] * 0.1f;



        }






    }

    public void AdjustAmbient(int overrideVolume)
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

            audioSource.volume = overrideVolume;
        }






    }
}
