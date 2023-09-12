using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Menu;

public class Transitions : MonoBehaviour
{

    [SerializeField]
    private GameObject settingTransition; //The transition screen that contains Gameplay/Sound setting transition buttons

    [SerializeField]
    private GameObject gameplaySettings; //Actual settings page

    [SerializeField]
    private GameObject gameplaySettingsClose; //Gameplay settings close button

    [SerializeField]
    private GameObject soundSettings; //Actual settings page

    [SerializeField]
    private GameObject soundSettingsClose; //Sound settings close button

    [SerializeField]
    private GameObject mainMenu; //Main menu object .Play,Options screen

    [SerializeField]
    private GameObject optionsBackground; //Background of options

    [SerializeField]
    private Dictionary_GameplaySettings gameplaySettingsScript;

    [SerializeField]
    private DictionaryVolumeSettings soundSettingsScript;

    


    private void Awake()
    {
        gameplaySettingsScript = FindObjectOfType<Dictionary_GameplaySettings>();

        soundSettingsScript = FindObjectOfType<DictionaryVolumeSettings>();
    }





    public void OpenGameplaySettings()
    {
        gameplaySettingsClose.SetActive(true);
        gameplaySettings.SetActive(true);
        settingTransition.SetActive(false);

    }

    public void CloseGameplaySettings()
    {
        
        gameplaySettings.SetActive(false);
        settingTransition.SetActive(true);
        gameplaySettingsClose.SetActive(false);
        gameplaySettingsScript.WriteToPlayerPrefsGameplay();

    }

    public void OpenSoundSettings()
    {
        soundSettingsClose.SetActive(true);
        soundSettings.SetActive(true);
        settingTransition.SetActive(false);

    }

    public void CloseSoundSettings()
    {
        soundSettings.SetActive(false);
        settingTransition.SetActive(true);
        soundSettingsClose.SetActive(false);
        soundSettingsScript.WriteToPlayerPrefsSound();
        gameplaySettingsScript.WriteToPlayerPrefsGameplay();
    }

    public void CloseOptions()
    {
        settingTransition.SetActive(false);
        mainMenu.SetActive(true);
        optionsBackground.SetActive(false);
    }

    public void OpenOptions()
    {
        settingTransition.SetActive(true);
        mainMenu.SetActive(false);
        optionsBackground.SetActive(true);
    }

}
