
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAdjustDictionary : MonoBehaviour
{
    [SerializeField]
    private Dictionary_GameplaySettings gameplaySettingsScript;
    [SerializeField]
    private SettingAssociations settingAssociations;

    [SerializeField]
    private Color opaque = new Color(1.0f, 1.0f, 1.0f, 1f);

    [SerializeField]
    private Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.5f);

    public void ChangeEnemySpawnFrequency(string difficulty)
    {
        string[] split = difficulty.Split(",", 2);
        string setting = split[0];
        string value = split[1];

        string associatedSetting = setting.ToUpper();

        gameplaySettingsScript.GameplaySettings[setting] = value; // Adjust the value to your desired value

        if (gameplaySettingsScript.GameplaySettings[setting] == "Easy")
        {
            settingAssociations.enemySpawnFrequency[0].GetComponent<Image>().color = opaque;
            settingAssociations.enemySpawnFrequency[1].GetComponent<Image>().color = transparent;
            settingAssociations.enemySpawnFrequency[2].GetComponent<Image>().color = transparent;
            Debug.Log("Difficulty is easy!");

        }

        else if (gameplaySettingsScript.GameplaySettings[setting] == "Medium")
        {
            Debug.Log("Difficulty is medium!");
            if (gameplaySettingsScript.TestingDictionary.TryGetValue("EnemySpawnFrequency", out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    Debug.Log("Settings accessed");
                    // Access the first object in the list.
                    Image firstImage = settingList[0];

                    // Do something with the firstImage object, for example:
                    firstImage.color = opaque;
                }
            }

            if (gameplaySettingsScript.GameplaySettings[setting] == "Hard")
            {
                Debug.Log("Difficulty is hard!");
            }



            //foreach (KeyValuePair<string, string> pair in gameplaySettingsScript.GameplaySettings)
            //{

            //    Debug.Log(pair.Key + ": " + pair.Value);
            //}


        }

    }
}
