using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Menu
{
    public class SettingAssociations : MonoBehaviour
    {

        public Dictionary_GameplaySettings dictionary;
        public Image[] enemySpawnFrequency;
        public Image[] shootingSpeed;



        private void Awake()
        {
            //Call the AddSettingList method in the Dictionary script to add settings to the dictionary.
            dictionary.AddSettingList("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));
            dictionary.AddSettingList("ShootingSpeed", new List<Image>(shootingSpeed));

        }

     




    }
}
