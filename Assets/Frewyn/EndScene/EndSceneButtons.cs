using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneButtons : MonoBehaviour
{
    [SerializeField]
    private Score score;
    [SerializeField]
    EndScene endScene;
    [SerializeField]
    GameObject objectEndScene;

    [Header("Stage Buttons")]
    [SerializeField]
    Image castleStage;
    [SerializeField]
    Image forestStage;
    [SerializeField]
    Image winterStage;

    [Header("Opacity")]
    [SerializeField]
    private Color opaque = new Color(1.0f, 1.0f, 1.0f, 1f);

    [SerializeField]
    private Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.5f);


    public enum Stage
    { 
        Castle,
        Forest,
        Winter
    
    }

    public Stage chosenStage ;





    public void CastleStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Castle;

        castleStage.color = opaque;
        forestStage.color = transparent;
        winterStage.color = transparent;

    }

    public void ForestStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Forest;

        castleStage.color = transparent;
        forestStage.color = opaque;
        winterStage.color = transparent;

    }


    public void WinterStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Winter;

        castleStage.color = transparent;
        forestStage.color = transparent;
        winterStage.color = opaque;
    }

    public void NextSession()

    {
        Debug.Log("Next session clicked! ");
        objectEndScene.SetActive(false);
        //endScene.TryAgain();
        //endScene.ResetScene();

    }


}
