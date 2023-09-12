using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Menu
{
    public class DictionaryVolumeSettings : MonoBehaviour
    {

        public Dictionary<string, float> SoundSettings = new Dictionary<string, float>()
        {

            {"Volume", 1},

            {"BGMusic", 1},

            {"ChargingSound", 1},

            {"Ambient", 1},

            {"SFX", 1},

            {"Crown", 1},

        };


        private void Awake()
        {

            InitalizeDictionaryWithPlayerPrefs();


            //foreach (KeyValuePair<string, float> pair in SoundSettings)//Writes out each settings with its key and value
            //{
            //    Debug.Log("Soundsettings " + pair.Key + ": " + pair.Value);
            //}


        }
        private void InitalizeDictionaryWithPlayerPrefs()
        {

            List<string> keysToUpdate = new List<string>(); //Used to store values that should be updated

            foreach (KeyValuePair<string, float> pair in SoundSettings)//Only adds to keysToUpdate if the value exists in playerprefs
            {
                if (PlayerPrefs.HasKey(pair.Key))
                {
                    Debug.Log("Existing key: " + pair.Key);
                    Debug.Log("Volume value: " + pair.Value);
                    keysToUpdate.Add(pair.Key);
                }
                else
                {
                    Debug.Log("Not existing key: " + pair.Key);
                }
            }

            foreach (string key in keysToUpdate)//Modify the dictioanry with playerprefs values if the values exist in playerprefs
            {
                if (PlayerPrefs.HasKey(key))
                {

                    UpdateDictionaryWithPlayerPrefs(key);
                }


            }

        }

        //Referenced https://forum.unity.com/threads/saving-player-prefs-with-enums.397304/
        private void UpdateDictionaryWithPlayerPrefs(string key) //Changes the values in dictionary into those in player prefs
        {
            SoundSettings[key] = PlayerPrefs.GetFloat(key); // Adjust the value to your desired value
        }
    


        public void WriteToPlayerPrefsSound() //Writes everything in the dictionary to playerprefs
        {

            Debug.Log("Writing sound settings to player prefs");
            foreach (KeyValuePair<string, float> pair in SoundSettings)
            {
                PlayerPrefs.SetFloat(pair.Key, pair.Value);
            }

        }











    }

}
