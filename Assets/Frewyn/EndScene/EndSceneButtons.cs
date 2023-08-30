using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private Color chosen = new Color32(242, 165, 65, 255);

    [SerializeField]
    private Color notChosen = new Color(255, 255, 255, 255);


    public enum Stage
    { 
        Castle,
        Forest,
        Winter
    
    }

    public Stage chosenStage ;



  

    public void Testing()
    {
        SceneManager.LoadScene("Winter");


    }

    public void CastleStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Castle;

        castleStage.color = chosen;
        forestStage.color = notChosen;
        winterStage.color = notChosen;

    }

    public void ForestStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Forest;

        castleStage.color = notChosen;
        forestStage.color = chosen;
        winterStage.color = notChosen;

    }


    public void WinterStage() //Sets chosen stage to x, changes opacity of all stage buttons
    {
        chosenStage = Stage.Winter;

        castleStage.color = notChosen;
        forestStage.color = notChosen;
        winterStage.color = chosen;
    }

    public void NextSession()

    {
        Debug.Log("Next session clicked! ");
        objectEndScene.SetActive(false);
        //endScene.TryAgain();
        //endScene.ResetScene();

    }

    public void GoForest()
    {
        SceneManager.LoadScene("Forest");


    }

    public void GoWinter()
    {
        SceneManager.LoadScene("Winter");


    }






}
