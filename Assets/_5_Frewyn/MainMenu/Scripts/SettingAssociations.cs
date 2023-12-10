using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Menu
{
    public class SettingAssociations : MonoBehaviour
    {

        public Dictionary_GameplaySettings dictionary;


        [Header("Player")]
    




        [Header("Enemy")]
        public Image[] enemySpawnFrequency;
       
        public Image[] enemyProjectileSpeed;
     


       [Header("Effects")]
        public Image[] particles;
        public Image[] screenShake;



        [Header("Volume")]
        //public Image[] BGMusic;

        //public Image[] chargingSound;
        //public Image[] sfx;
        //public Image[] crown;   
        public Image[] mute;





        private void Awake()
        {
            dictionary = FindObjectOfType<Dictionary_GameplaySettings>();

            if (!FindObjectOfType<Dictionary_GameplaySettings>()) { SceneManager.LoadScene(0); }

            dictionary.ButtonDictionary.Clear();

            //Call the AddSettingList method in the Dictionary script to add settings to the dictionary.


            dictionary.AddToButtonDictionary("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));
       
            dictionary.AddToButtonDictionary("EnemyProjectileSpeed", new List<Image>(enemyProjectileSpeed));

            dictionary.AddToButtonDictionary("Particles", new List<Image>(particles));

            dictionary.AddToButtonDictionary("ScreenShake", new List<Image>(screenShake));



            //dictionary.AddToButtonDictionary("BGMusic", new List<Image>(BGMusic));

            //dictionary.AddToButtonDictionary("ChargingSound", new List<Image>(chargingSound));

            //dictionary.AddToButtonDictionary("SFX", new List<Image>(sfx));

            //dictionary.AddToButtonDictionary("Crown", new List<Image>(crown));

            dictionary.AddToButtonDictionary("Mute", new List<Image>(mute));



        }






    }
}
