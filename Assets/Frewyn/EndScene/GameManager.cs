using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject endSceneObject;

    [SerializeField]
    private static GameManager instance;


    [SerializeField]
    private SOScore soScore;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnApplicationQuit() 
    {
        
        for(int i=0; i<soScore.scores.Length;i++) //Clears the scriptable object used to keep track of scores.
        {
            soScore.scores[i] = 0;
           //EndScene.timesPlayed = 0;
        }
          
    }





}
