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
        public Image[] mute;





        private void Awake()
        {
            dictionary = FindObjectOfType<Dictionary_GameplaySettings>();
            //If can't find the dictionary, rerun the preload
            if (!@FindObjectOfType<Dictionary_GameplaySettings>()) { SceneManager.LoadScene(0); }



            //Call the AddSettingList method in the Dictionary script to add settings to the dictionary.
     

            dictionary.AddToButtonDictionary("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));
       
            dictionary.AddToButtonDictionary("EnemyProjectileSpeed", new List<Image>(enemyProjectileSpeed));

            dictionary.AddToButtonDictionary("Particles", new List<Image>(particles));

            dictionary.AddToButtonDictionary("ScreenShake", new List<Image>(screenShake));


            dictionary.AddToButtonDictionary("Mute", new List<Image>(mute));



        }






    }
}
