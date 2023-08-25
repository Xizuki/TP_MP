using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneOriginal : MonoBehaviour
{
    public Score score;
    public int timePressed;
    public Button tryAgain;
    public GameTimer gameTimer;
    public float highScore;
    public Image[] progressBars;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetFloat("Highscore");
        }
        else
        {
            highScore = 0;
            for (int i = 0; i < progressBars.Length; i++)
            {
                progressBars[i].fillAmount = 0;
            }

            PlayerPrefs.SetFloat("Highscore", highScore);
        }

        if (PlayerPrefs.HasKey("Timepressed"))
        {
            timePressed = PlayerPrefs.GetInt("Timepressed");
        }
        else
        {
            timePressed = 0;
            PlayerPrefs.SetInt("Timepressed", timePressed);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(gameTimer.gameEnded == true)
        {
            highScore = score.score;

            if (highScore > PlayerPrefs.GetFloat("Highscore"))
            {
                PlayerPrefs.SetFloat("Highscore", highScore);
            }
            //progressBars[timePressed].fillAmount = highScore / highScore;
        }

    }

    public void TryAgain()
    {
        timePressed += timePressed + 1;
        PlayerPrefs.SetInt("Timepressed", timePressed);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
