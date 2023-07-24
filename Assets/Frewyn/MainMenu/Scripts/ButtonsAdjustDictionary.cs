using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAdjustDictionary : MonoBehaviour
{
    [SerializeField]
    private Dictionary_GameplaySettings gameplaySettingsScript;

    void Start()
    {


    }

    public void ChangeEnemySpawnFrequency(string difficulty)
    {

        string[] split  = difficulty.Split(",", 2);
        string setting = split[0];
        string value = split[1];

        gameplaySettingsScript.GameplaySettings[setting] = value; // Adjust the value to your desired value
        foreach (KeyValuePair<string, string> pair in gameplaySettingsScript.GameplaySettings)
        {

            Debug.Log(pair.Key + ": " + pair.Value);
        }
    }

}
