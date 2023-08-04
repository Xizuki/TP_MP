using JetBrains.Annotations;
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

namespace Menu
{
    public class Dictionary_GameplaySettings : MonoBehaviour
    {
        public Dictionary<string, List<Image>> ButtonDictionary = new Dictionary<string, List<Image>>()

        {

        };

      

        public Dictionary<string, Difficulty> GameplaySettings = new Dictionary<string, Difficulty>()
        {

            {"PlayerJumpHeight", Difficulty.Easy},

            {"EnemySpawnFrequency", Difficulty.Easy},
            {"EnemyMovementSpeed", Difficulty.Easy},
            {"EnemyProjectileSpeed", Difficulty.Easy},
            {"EnemyDisappearOnAttack", Difficulty.On},

            {"PowerupSpawnFrequency", Difficulty.Easy},

            {"Mute", Difficulty.Off},

        };

        public Dictionary<string, int> SoundSettings = new Dictionary<string, int>()
        {

            {"Volume", 0}

        };


        private void Awake()
        {

            InitalizeDictionaryWithPlayerPrefs();


            foreach (KeyValuePair<string, Difficulty> pair in GameplaySettings)//Writes out each settings with its key and value
            {
                Debug.Log("Gameplay settings: " + pair.Key + ": " + pair.Value);
            }


        }
        private void InitalizeDictionaryWithPlayerPrefs()
        {

            List<string> keysToUpdate = new List<string>(); //Used to store values that should be updated

            foreach (KeyValuePair<string, Difficulty> pair in GameplaySettings)//Only adds to keysToUpdate if the value exists in playerprefs
            {
                if (PlayerPrefs.HasKey(pair.Key))
                {
                    Debug.Log("Existing key: " + pair.Key);
                    keysToUpdate.Add(pair.Key);
                }
                else
                {
                    Debug.Log("Not existing key: " + pair.Key);
                }
            }


            foreach (string key in keysToUpdate)//Modify the dictioanry with playerprefs values if the values exist in playerprefs
            {   
                if(PlayerPrefs.HasKey(key))                
                {

                    UpdateDictionaryWithPlayerPrefs(key);
                }
            
             
            }

        }

        //Referenced https://forum.unity.com/threads/saving-player-prefs-with-enums.397304/
        private void UpdateDictionaryWithPlayerPrefs(string key) //Changes the values in dictionary into those in player prefs
        {
            GameplaySettings[key] = GetPlayerPrefValue(key); // Adjust the value to your desired value
        }
        private Difficulty GetPlayerPrefValue(string key) //Get the difficulty in player prefs as a enum
        {
            Difficulty something = (Difficulty)System.Enum.Parse(typeof(Difficulty), PlayerPrefs.GetString(key));
            return something;
        }



        public void WriteToPlayerPrefsGameplay() //Writes everything in the dictionary to playerprefs
        {
            Debug.Log("Writing gameplay settings to player prefs");

            foreach (KeyValuePair<string, Difficulty> pair in GameplaySettings)
            {

                //Debug.Log("Gameplay settings: " + pair.Key + ": " + pair.Value);
                PlayerPrefs.SetString(pair.Key, pair.Value.ToString());
            }

        }



      



        //Add a list of buttons to ButtonDictionary
        public void AddToButtonDictionary(string settingName, List<Image> settingList)
        {
            // Check if the settingName already exists in the dictionary.
            if (ButtonDictionary.ContainsKey(settingName))
            {
                Debug.Log("Setting '" + settingName + "' already exists in the GameplaySettings dictionary.");
                return;
            }

            // Add the settingList to the dictionary.
            ButtonDictionary.Add(settingName, settingList);
        }


        //Edit list in ButtonDictionary
        public void EditSettingList(string settingName, List<Image> settingList)

        {
            // Add the settingList to the dictionary.
            ButtonDictionary[settingName] = settingList;
        }



    }

}
