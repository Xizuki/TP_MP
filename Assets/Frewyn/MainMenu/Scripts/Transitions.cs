using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Menu;

public class Transitions : MonoBehaviour
{

    [SerializeField]
    private GameObject settingTransition;

    [SerializeField]
    private GameObject gameplaySettings;

    [SerializeField]
    private GameObject gameplaySettingsClose;

    [SerializeField]
    private GameObject soundSettings;

    [SerializeField]
    private GameObject soundSettingsClose;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject optionsBackground;

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
        Debug.Log("Click");
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
