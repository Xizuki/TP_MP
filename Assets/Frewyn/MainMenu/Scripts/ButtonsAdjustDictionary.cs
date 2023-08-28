
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
        private DictionaryVolumeSettings volumeSettingsScript;
        [SerializeField]
        private SettingAssociations settingAssociations;
    

        [SerializeField]
        private Color opaque = new Color(1.0f, 1.0f, 1.0f, 1f);

        [SerializeField]
        private Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.5f);

     


        private void Start()
        {
            CheckDifficulty("PlayerJumpHeight");

            CheckDifficulty("EnemySpawnFrequency");
            CheckDifficulty("EnemyMovementSpeed");
            CheckDifficulty("EnemyProjectileSpeed");
            CheckOnOff("EnemyDisappearOnAttack");

            CheckDifficulty("PowerupSpawnFrequency");

            CheckOnOff("Mute");

        }

        public void EasyPreset()//Sets settings to easy difficulty
        {
            gameplaySettingsScript.GameplaySettings["PlayerJumpHeight"] = Difficulty.Easy;

            gameplaySettingsScript.GameplaySettings["EnemySpawnFrequency"] = Difficulty.Easy;
            gameplaySettingsScript.GameplaySettings["EnemyMovementSpeed"] = Difficulty.Easy;
            gameplaySettingsScript.GameplaySettings["EnemyProjectileSpeed"] = Difficulty.Easy;
            gameplaySettingsScript.GameplaySettings["EnemyDisappearOnAttack"] = Difficulty.On;

            gameplaySettingsScript.GameplaySettings["PowerupSpawnFrequency"] = Difficulty.Easy;

            CheckDifficulty("PlayerJumpHeight");

            CheckDifficulty("EnemySpawnFrequency");
            CheckDifficulty("EnemyMovementSpeed");
            CheckDifficulty("EnemyProjectileSpeed");
            CheckOnOff("EnemyDisappearOnAttack");

            CheckDifficulty("PowerupSpawnFrequency");

        }

        public void MediumPreset() //Sets settings to medium difficulty
        {
            gameplaySettingsScript.GameplaySettings["PlayerJumpHeight"] = Difficulty.Medium;

            gameplaySettingsScript.GameplaySettings["EnemySpawnFrequency"] = Difficulty.Medium;
            gameplaySettingsScript.GameplaySettings["EnemyMovementSpeed"] = Difficulty.Medium;
            gameplaySettingsScript.GameplaySettings["EnemyProjectileSpeed"] = Difficulty.Medium;
            gameplaySettingsScript.GameplaySettings["EnemyDisappearOnAttack"] = Difficulty.On;

            gameplaySettingsScript.GameplaySettings["PowerupSpawnFrequency"] = Difficulty.Medium;

            CheckDifficulty("PlayerJumpHeight");

            CheckDifficulty("EnemySpawnFrequency");
            CheckDifficulty("EnemyMovementSpeed");
            CheckDifficulty("EnemyProjectileSpeed");
            CheckOnOff("EnemyDisappearOnAttack");

            CheckDifficulty("PowerupSpawnFrequency");
        }

        public void HardPreset() //Sets settings to hard difficulty
        {
            gameplaySettingsScript.GameplaySettings["PlayerJumpHeight"] = Difficulty.Hard;

            gameplaySettingsScript.GameplaySettings["EnemySpawnFrequency"] = Difficulty.Hard;
            gameplaySettingsScript.GameplaySettings["EnemyMovementSpeed"] = Difficulty.Hard;
            gameplaySettingsScript.GameplaySettings["EnemyProjectileSpeed"] = Difficulty.Hard;
            gameplaySettingsScript.GameplaySettings["EnemyDisappearOnAttack"] = Difficulty.Off;

            gameplaySettingsScript.GameplaySettings["PowerupSpawnFrequency"] = Difficulty.Hard;

            CheckDifficulty("PlayerJumpHeight");

            CheckDifficulty("EnemySpawnFrequency");
            CheckDifficulty("EnemyMovementSpeed");
            CheckDifficulty("EnemyProjectileSpeed");
            CheckOnOff("EnemyDisappearOnAttack");

            CheckDifficulty("PowerupSpawnFrequency");
        }



        public void CheckOnOff(string setting)//Used to change the opacity of buttons depending on which was chosen
        {

            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    Debug.Log(setting);
                    Difficulty difficulty = gameplaySettingsScript.GameplaySettings[setting];

                    Image onButton = settingList[0];
                    Image offButton = settingList[1];
 
                    if (difficulty == Difficulty.On)
                    {
                        onButton.color = opaque;
                        offButton.color = transparent;
                 
                    }
                    else if (difficulty == Difficulty.Off)
                    {
                        onButton.color = transparent;
                        offButton.color = opaque;
                   
                    }
              

                }

            }
        }

        public void CheckDifficulty(string setting) //Used to change the opacity of buttons depending on which was chosen
        {

            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                //  access list elements using indices.
                if (settingList.Count > 0)
                {
                    //Difficulty difficulty = (Difficulty)System.Enum.Parse(typeof(Difficulty), PlayerPrefs.GetString(setting));

                    Difficulty difficulty = gameplaySettingsScript.GameplaySettings[setting];

                    Image easyButton = settingList[0];
                    Image mediumButton = settingList[1];
                    Image hardButton = settingList[2];

                    if (difficulty == Difficulty.Easy)
                    {
                        easyButton.color = opaque;
                        mediumButton.color = transparent;
                        hardButton.color = transparent;
                    }
                    else if (difficulty == Difficulty.Medium)
                    {
                        easyButton.color = transparent;
                        mediumButton.color = opaque;
                        hardButton.color = transparent;
                    }
                    else if (difficulty == Difficulty.Hard)
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

        public void MediumDifficulty(string setting)//Medium difficulty of a setting, sets the opacity of the buttons
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

        public void HardDifficulty(string setting) //Hard difficulty of a setting, sets the opacity of the buttons
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

        public void SettingOn(string setting)
        {
            gameplaySettingsScript.GameplaySettings[setting] = Difficulty.On; // Adjust the value to your desired value
            Debug.Log("Setting On");
            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    //Debug.Log("Settings accessed");
                    // Access the objects in the list.
                    Image onButton = settingList[0];
                    Image offButton = settingList[1];


                    // Do something with the firstImage object, for example:
                    onButton.color = opaque;
                    offButton.color = transparent;
                  
                }
            }

        }

        public void SettingOff(string setting)
        {
            gameplaySettingsScript.GameplaySettings[setting] = Difficulty.Off; // Adjust the value to your desired value
            Debug.Log("Setting Off");
            if (gameplaySettingsScript.ButtonDictionary.TryGetValue(setting, out List<Image> settingList))
            {
                // Now you have the list, you can access its elements using indices.
                if (settingList.Count > 0)
                {
                    //Debug.Log("Settings accessed");
                    // Access the objects in the list.
                    Image onButton = settingList[0];
                    Image offButton = settingList[1];

                    // Do something with the firstImage object, for example:
                    onButton.color = transparent;
                    offButton.color = opaque;

                }
            }

        }


        public void SaveGameplaySettings()
        {
         

            gameplaySettingsScript.WriteToPlayerPrefsGameplay();

   
        }

        public void SaveSoundSettings()
        {


            volumeSettingsScript.WriteToPlayerPrefsSound();


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
