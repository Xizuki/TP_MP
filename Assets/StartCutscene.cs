using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour
{
    public Animator camAnim;
    public Canvas UI;
    public Canvas UI2;

    public Button skipButton;
    public Animator blackBars;

    public GameObject gameHasStart;
    public bool gameHasStarted;
    public bool gameHasSkip;
    // Start is called before the first frame update
    void Start()
    {
        /*UI.enabled = false;
        UI2.enabled = false;
        gameHasStart.SetActive(false);
        gameHasStarted = false;
        gameHasSkip = false;
        StartCoroutine(TimeWait());*/
    }

    IEnumerator TimeWait()
    {
        skipButton.enabled = true;
        UI.enabled = false;
        UI2.enabled = false;
        blackBars.enabled = true;
        blackBars.SetTrigger("Show");
        gameHasStart.SetActive(false);
        yield return new WaitForSeconds(4.5f);
        UI.enabled = true;
        UI2.enabled = true;
        gameHasStarted = true;
/*        if (gameHasSkip == false)
        {
            StartCoroutine(GameStart());
        }*/
        blackBars.SetTrigger("Hide");
        camAnim.SetTrigger("EndCutscene");
        yield return new WaitForSeconds(1f);
        camAnim.enabled = false;
        skipButton.enabled = false;
    }

    IEnumerator CutsceneSkip()
    {
        gameHasSkip = true;
        blackBars.SetTrigger("Hide");
        camAnim.SetTrigger("EndCutscene");
        yield return new WaitForSeconds(1f);
        skipButton.enabled = false;
        camAnim.enabled = false;
        UI.enabled = true;
        UI2.enabled = true;
    }

    public void StartCutscenes()
    {
        StartCoroutine(TimeWait());
    }

    public void SkipCutscene()
    {
        StartCoroutine(CutsceneSkip());
    }

    /*IEnumerator GameStart()
    {
        *//*if (gameHasStarted == true)
        {
            gameHasStart.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            gameHasStart.SetActive(false);
            gameHasStarted = false;
        }*//*

    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
