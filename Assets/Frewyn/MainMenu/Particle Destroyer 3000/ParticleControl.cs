using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleControl : MonoBehaviour
{


    private Dictionary_GameplaySettings dictionary;
    private void Awake()
    {

        dictionary = FindObjectOfType<Dictionary_GameplaySettings>();   
    }
    void Start()
    {
        if (dictionary.GameplaySettings["Particles"] == Difficulty.Off) //Only calls if particles are off
        {
            GameObject[] objectToDisable = GameObject.FindGameObjectsWithTag("Particles");//Find objects with the particle tag

            foreach (GameObject objects in objectToDisable)
            {
                Destroy(objects); //Destroy all objects in objectToDisable
            }
        }
    }


}
