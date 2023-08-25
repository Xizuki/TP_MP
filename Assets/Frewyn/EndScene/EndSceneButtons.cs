using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndSceneButtons : MonoBehaviour
{
    [SerializeField]
    private Score score;
    [SerializeField]
    EndScene endScene;
    [SerializeField]
    GameObject objectEndScene;


    public enum Stage
    { 
        Castle,
        Forest,
        Winter
    
    }

    Stage chosenStage ;





    public void CastleStage()
    {
        chosenStage = Stage.Castle;
        
    }

    public void ForestStage()
    {
        chosenStage = Stage.Forest;

    }


    public void WinterStage()
    {
        chosenStage = Stage.Winter;

    }

    public void NextSession()

    {
        Debug.Log("Next session clicked! ");
        objectEndScene.SetActive(false);
        endScene.TryAgain();

    }


}
