using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using Menu;

public class Transitions : MonoBehaviour
{

    [SerializeField]
    private GameObject settingTransition;

    [SerializeField]
    private GameObject gameplaySettings;

    [SerializeField]
    private GameObject soundSettings;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject optionsBackground;

    [SerializeField]
    private Dictionary_GameplaySettings gameplaySettingsScript;

    [SerializeField]
    private DictionaryVolumeSettings soundSettingsScript;





    public void OpenGameplaySettings()
    {
        gameplaySettings.SetActive(true);
        settingTransition.SetActive(false);

    }

    public void CloseGameplaySettings()
    {
        Debug.Log("Click");
        gameplaySettings.SetActive(false);
        settingTransition.SetActive(true);
        gameplaySettingsScript.WriteToPlayerPrefsGameplay();

    }

    public void OpenSoundSettings()
    {
        soundSettings.SetActive(true);
        settingTransition.SetActive(false);

    }

    public void CloseSoundSettings()
    {
        soundSettings.SetActive(false);
        settingTransition.SetActive(true);
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
