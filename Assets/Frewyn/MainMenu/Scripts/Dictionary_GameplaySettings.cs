using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

/*
A dictionary that is used to store the settings, format will be:
Settings name , value.
For example : Movement Speed, Medium
*/
public class Dictionary_GameplaySettings : MonoBehaviour
{
    public SettingAssociations settingAssociations;




    public Dictionary<string, List<Image>> TestingDictionary = new Dictionary<string, List<Image>>()

    {


   


    };



    public Dictionary<string, string> GameplaySettings = new Dictionary<string, string>()

    {
        {"EnemySpawnFrequency", "Medium" }

    };



    // Method to add the testList to the GameplaySettings dictionary.
    public void AddSettingList(string settingName, List<Image> settingList)
    {
        //// Check if the settingName already exists in the dictionary.
        //if (GameplaySettings.ContainsKey(settingName))
        //{
        //    Debug.Log("Setting '" + settingName + "' already exists in the GameplaySettings dictionary.");
        //    return;
        //}

        // Add the settingList to the dictionary.
        TestingDictionary.Add(settingName, settingList);
    }




    private void Awake()
    {
        foreach (KeyValuePair<string, string> pair in GameplaySettings)
        {
            Debug.Log(pair.Key + ": " + pair.Value);
        }

        foreach (KeyValuePair<string, List<Image>> pair in TestingDictionary)
        {
            Debug.Log("Something");
            Debug.Log(pair.Key + ": " + pair.Value);
        }

    }

 




 
}
