using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/*
A dictionary that is used to store the settings, format will be:
Settings name , value.
For example : Movement Speed, Medium
*/
public class Dictionary_GameplaySettings : MonoBehaviour
{


    public Dictionary<string, string> GameplaySettings = new Dictionary<string, string>();

    private void Awake()
    {

        GameplaySettings.Add("EnemySpawnFrequency", "Medium");

        foreach (KeyValuePair<string, string> pair in GameplaySettings)
        {
            Debug.Log(pair.Key + ": " + pair.Value);
        }

    }

 




 
}
