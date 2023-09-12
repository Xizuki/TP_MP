using Menu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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



        AdjustBGVolume();

        AdjustChargingVolume();

        AdjustSFXVolume();

        AdjustCrownVolume();

        AdjustAmbient();
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
        
       Music audioSourceToAdjust = FindObjectOfType<Music>();//Find the script that handles BG Music

        //Adjust the audio source volume by multiplying it with the BG Music value found in the settings/dictionary, 
        //This line is necessary as menu doesn't contain this script and everything breaks if audioSourceToAdjust is empty
        if (audioSourceToAdjust != null)
        {
            audioSourceToAdjust.music.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["BGMusic"] * 0.1f;
        }


        //Below implementation is meant spefically for menu as menu's BG music isn't handle through Music Script
        GameObject[] bgSound = GameObject.FindGameObjectsWithTag("BGMusic");

        //AudioSource[] ambientAudioSources = new AudioSource[ambientObjects.Length];

        foreach (GameObject gameObject in bgSound)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["BGMusic"] * 0.1f;



        }
    }

        void AdjustChargingVolume()
    {


        //If there is a chargingsfx then do this, this is necessary as menu doesn't contain chargingSFX which will  cause error if it is null.
        if(chargingSFX!=null)
        chargingSFX.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f;

        Debug.Log("Charging adjusted " + soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["ChargingSound"] * 0.1f);


    }


    void AdjustSFXVolume()
    {
      

        GameObject[] sfx = GameObject.FindGameObjectsWithTag("SFX");

        


        foreach (GameObject gameObject in sfx)
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

        GameObject[] crown = GameObject.FindGameObjectsWithTag("Crown"); //Finds object with tag 


        foreach (GameObject gameObject in crown)//For every object found, adjust its volume according to sound settings
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"] * 0.1f * soundDictionary.SoundSettings["Crown"] * 0.1f;



        }
    }

    void AdjustAmbient()
    {

        GameObject[] ambientObjects = GameObject.FindGameObjectsWithTag("Ambient"); //Finds object with tag 



        foreach (GameObject gameObject in ambientObjects)//For every object found, adjust its volume according to sound settings
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = soundDictionary.SoundSettings["Volume"]*0.1f * soundDictionary.SoundSettings["Ambient"] * 0.1f;



        }






    }
}
