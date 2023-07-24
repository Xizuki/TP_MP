using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingAssociations : MonoBehaviour
{

    public Dictionary_GameplaySettings dictionary;
    public Image[] enemySpawnFrequency;




    private void Awake()
    {
        // Call the AddSettingList method in the Dictionary script to add testList to the dictionary.
        dictionary.AddSettingList("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));

        //dictionary.TestingDictionary.Add("EnemySpawnFrequency", new List<Image>(enemySpawnFrequency));


    }




}
