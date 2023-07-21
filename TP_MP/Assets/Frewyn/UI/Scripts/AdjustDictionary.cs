using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDictionary : MonoBehaviour
{
    [SerializeField]
    private Dictionary_GameplaySettings gameplaySettingsScript;

   


    void Start()
    {
        
        //gameplaySettingsScript.GameplaySettings.Add("TestingExample", "Easy");
        //gameplaySettingsScript.GameplaySettings["EnemySpawnFrequency"] = "Hard"; // Adjust the value to your desired value
        //foreach (KeyValuePair<string, string> pair in gameplaySettingsScript.GameplaySettings)
        //{
        //    Debug.Log(pair.Key + ": " + pair.Value);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
