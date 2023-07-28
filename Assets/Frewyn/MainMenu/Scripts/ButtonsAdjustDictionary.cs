
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Menu
{
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



        private void Start()
        {
            CheckDifficulty("EnemySpawnFrequency");

            CheckDifficulty("ShootingSpeed");

        }

        public void CheckDifficulty(string setting)
        {

            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    Difficulty something = (Difficulty)System.Enum.Parse(typeof(Difficulty), PlayerPrefs.GetString(setting));

                    Image easyButton = settingList[0];
                    Image mediumButton = settingList[1];
                    Image hardButton = settingList[2];

                    if (something == Difficulty.Easy)
                    {
                        easyButton.color = opaque;
                        mediumButton.color = transparent;
                        hardButton.color = transparent;
                    }
                    else if (something == Difficulty.Medium)
                    {
                        easyButton.color = transparent;
                        mediumButton.color = opaque;
                        hardButton.color = transparent;
                    }
                    else if (something == Difficulty.Hard)
                    {
                        easyButton.color = transparent;
                        mediumButton.color = transparent;
                        hardButton.color = opaque;
                    }


                }
            }
        }

        public void EasyDifficulty(string setting) //Pass in a string with the setting name, sets that setting to string passed in, change opacity of buttons
        {
            gameplaySettingsScript.GameplaySettings[setting] = Difficulty.Easy; // Adjust the value to your desired value
            Debug.Log("Difficulty is Easy!");
            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    //Debug.Log("Settings accessed");
                    // Access the objects in the list.
                    Image easyButton = settingList[0];
                    Image mediumButton = settingList[1];
                    Image hardButton = settingList[2];

                    // Do something with the firstImage object, for example:
                    easyButton.color = opaque;
                    mediumButton.color = transparent;
                    hardButton.color = transparent;
                }
            }
        }

        public void MediumDifficulty(string setting)
        {
            gameplaySettingsScript.GameplaySettings[setting] = Difficulty.Medium; // Adjust the value to your desired value
            Debug.Log("Difficulty is Medium!");
            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    //Debug.Log("Settings accessed");
                    // Access the objects in the list.
                    Image easyButton = settingList[0];
                    Image mediumButton = settingList[1];
                    Image hardButton = settingList[2];

                    // Do something with the firstImage object, for example:
                    easyButton.color = transparent;
                    mediumButton.color = opaque;
                    hardButton.color = transparent;
                }
            }
        }

        public void HardDifficulty(string setting)
        {
            gameplaySettingsScript.GameplaySettings[setting] = Difficulty.Hard; // Adjust the value to your desired value
            Debug.Log("Difficulty is Hard!");
            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    //Debug.Log("Settings accessed");
                    // Access the objects in the list.
                    Image easyButton = settingList[0];
                    Image mediumButton = settingList[1];
                    Image hardButton = settingList[2];

                    // Do something with the firstImage object, for example:
                    easyButton.color = transparent;
                    mediumButton.color = transparent;
                    hardButton.color = opaque;
                }
            }
            
        }


        public void Save()
        {
            Debug.Log("Inital values Spawn Frequency: " + PlayerPrefs.GetString("EnemySpawnFrequency"));

            Debug.Log("Inital values Shooting Speed: " + PlayerPrefs.GetString("ShootingSpeed"));


            gameplaySettingsScript.WriteToPlayerPrefs();

            Debug.Log("New values Spawn Frequency: " + PlayerPrefs.GetString("EnemySpawnFrequency"));

            Debug.Log("New values Shooting Speed: " + PlayerPrefs.GetString("ShootingSpeed"));

        }





        //public void ChangeEnemySpawnFrequency(string difficulty)
        // {


        //        string[] split = difficulty.Split(",", 2);
        //        string setting = split[0];
        //        string value = split[1];

        //        string associatedSetting = setting.ToUpper();

        //        gameplaySettingsScript.GameplaySettings[setting] = value; // Adjust the value to your desired value

        //        if (gameplaySettingsScript.GameplaySettings[setting] == "Easy")
        //        {
        //            settingAssociations.enemySpawnFrequency[0].GetComponent<Image>().color = opaque;
        //            settingAssociations.enemySpawnFrequency[1].GetComponent<Image>().color = transparent;
        //            settingAssociations.enemySpawnFrequency[2].GetComponent<Image>().color = transparent;
        //            Debug.Log("Difficulty is easy!");

        //        }

        //        else if (gameplaySettingsScript.GameplaySettings[setting] == "Medium")
        //        {
        //            Debug.Log("Difficulty is medium!");
        //            if (gameplaySettingsScript.TestingDictionary.TryGetValue("EnemySpawnFrequency", out List<Image> settingList))
        //            {
        //                // Now you have the list, you can access its elements using indices.
        //                if (settingList.Count > 0)
        //                {
        //                    Debug.Log("Settings accessed");
        //                    // Access the first object in the list.
        //                    Image firstImage = settingList[0];

        //                    // Do something with the firstImage object, for example:
        //                    firstImage.color = opaque;
        //                }
        //            }

        //            if (gameplaySettingsScript.GameplaySettings[setting] == "Hard")
        //            {
        //                Debug.Log("Difficulty is hard!");
        //            }



        //            //foreach (KeyValuePair<string, string> pair in gameplaySettingsScript.GameplaySettings)
        //            //{

        //            //    Debug.Log(pair.Key + ": " + pair.Value);
        //            //}


        //        }

        // }
    }
}
