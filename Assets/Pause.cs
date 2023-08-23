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
    public bool gamePause;

    public void PauseGame()
    {
        gamePause = true;
        playerControl.enabled = false;
        AudioListener.pause = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePause=false;
        playerControl.enabled = true;
        //StartCoroutine(EnableSound());
        AudioListener.pause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

/*    IEnumerator EnableSound()
    {
        yield return new WaitForSeconds(0.5f);
        AudioListener.volume = 1f;
        AudioListener.pause = false;
    }*/

    public void MainMenu()
    {
        playerControl.enabled = true;
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePause == false)
        {
            Debug.Log("pause");
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePause == true)
        {
            Debug.Log("unpause");
            ResumeGame();
        }
    }

}
