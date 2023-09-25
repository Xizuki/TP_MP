using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timetTest;

    public float timerOriginal;
    public float timer;
    public bool gameEnded;

    public bool timerEnabled = false;

    [SerializeField]
    private GameObject endScene;
    void Start()
    {
    }

    void LateUpdate()
    {
        if (timerEnabled==true)
        {
            if (gameEnded)
            {
                endScene.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameEnded=false;    
            }

            //timer -= Time.deltaTime;
            //timetTest.text = "Timer:" + Mathf.Round(timer);
            //if (timer <= 0)
            //{
            //    Time.timeScale = 0;
            //    endScene.gameObject.SetActive(true);
            //    gameEnded = true;
            //}
        }
       
        
    }

}
