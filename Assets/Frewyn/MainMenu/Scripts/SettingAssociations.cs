using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Menu
{
    public class SettingAssociations : MonoBehaviour
    {

        public Dictionary_GameplaySettings dictionary;
        [Header("Player")]
        public Image[] playerJumpHeight;




        [Header("Enemy")]
        public Image[] enemySpawnFrequency;
        public Image[] enemyMovementSpeed;
        public Image[] enemyProjectileSpeed;
        public Image[] enemyDisappearOnAttack;



        [Header("Powerup")]
        public Image[] powerupSpawnFrequency;


        [Header("Volume")]
        public Image[] mute;





        private void Awake()
        {
            //Call the AddSettingList method in the Dictionary script to add settings to the dictionary.
            dictionary.AddToButtonDictionary("PlayerJumpHeight", new List<Image>(playerJumpHeight));

            dictionary.AddToButtonDictionary("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));
            dictionary.AddToButtonDictionary("EnemyMovementSpeed", new List<Image>(enemyMovementSpeed));
            dictionary.AddToButtonDictionary("EnemyProjectileSpeed", new List<Image>(enemyProjectileSpeed));
            dictionary.AddToButtonDictionary("EnemyDisappearOnAttack", new List<Image>(enemyDisappearOnAttack));

            dictionary.AddToButtonDictionary("PowerupSpawnFrequency", new List<Image>(powerupSpawnFrequency));

            dictionary.AddToButtonDictionary("Mute", new List<Image>(mute));



        }






    }
}
