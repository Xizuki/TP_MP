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

    void Update()
    {
        if (timerEnabled==true)
        {
            timer -= Time.deltaTime;
            timetTest.text = "Timer:" + Mathf.Round(timer);
            if (timer <= 0)
            {
                Time.timeScale = 0;
                endScene.gameObject.SetActive(true);
                gameEnded = true;
            }
        }
       
        
    }

}
