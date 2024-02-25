using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public Button pause;
    public GameObject pauseMenu;
    public JumpingPlayerScript playerControl;
    public AudioSource pauseSound;
    public bool gamePause;

    
    
    public bool asyncForcePause;
    public bool asyncForceResume;

    public GameObject soundSettings;

    public GameObject settingsButton;

    public GameObject mainMenuButton;

    public bool nonMain;

    public void OpenSoundSettings() //Done by frewyn, disables the sound settings
    {
        settingsButton.SetActive(false);
        mainMenuButton.SetActive(false);

        soundSettings.SetActive(true);

    }

    public void CloseSoundSettings() //Done by frewyn, enables the sound settings
    {
        settingsButton.SetActive(true);
        mainMenuButton.SetActive(true);

        soundSettings.SetActive(false);

    }


    public void PauseGame()
    {
        //if (soundSettings.activeInHierarchy && !nonMain) return;

        
        Time.timeScale = 0f;
        playerControl.enabled = false;
        //print("PauseGamePauseGame 1");

        //if (GetComponentInParent<CanvasScript>().gameTimer.gameEnded) return;
        //if (nonMain) return;
        pauseSound.ignoreListenerPause = true;
        pauseMenu.SetActive(true);

        settingsButton.SetActive(true); //Done by frewyn, sets buttons to activee
        mainMenuButton.SetActive(true); //Done by frewyn, sets buttons to activee

        gamePause = true;
        AudioListener.pause = true; 

        //print("PauseGamePauseGame 2");
    }

    public void ResumeGame()
    {
        pauseSound.Play();
        gamePause = false;
        playerControl.enabled = true;

        if (GetComponentInParent<CanvasScript>().gameTimer.gameEnded) return;
        if (nonMain) return;


        soundSettings.SetActive(false);
        //StartCoroutine(EnableSound());
        AudioListener.pause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        //print("ResumeGameResumeGame");

    }

    /*    IEnumerator EnableSound()
        {
            yield return new WaitForSeconds(0.5f);
            AudioListener.volume = 1f;
            AudioListener.pause = false;
        }*/

    public void MainMenu()
    {
        pauseSound.Play();
        playerControl.enabled = true;
        AudioListener.pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void CloseIntervalSettings()
    {
        pauseMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
        gamePause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (asyncForcePause)
        {
            PauseGame();
            //asyncForcePause = false;
        }
        if (asyncForceResume)
        {
            ResumeGame();
            //asyncForceResume = false;
        }


        if (Input.GetKeyDown(KeyCode.Escape) && gamePause == false && !nonMain)
        {
            Debug.Log("pause");
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePause == true && !nonMain)
        {
            Debug.Log("unpause");
            ResumeGame();
        }
    }

}
