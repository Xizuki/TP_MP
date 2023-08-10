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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeWait());
    }

    IEnumerator TimeWait()
    {
        skipButton.enabled = true;
        UI.enabled = false;
        UI2.enabled = false;
        blackBars.enabled = true;
        blackBars.SetTrigger("Show");
        yield return new WaitForSeconds(4.5f);
        UI.enabled = true;
        UI2.enabled = true;
        blackBars.SetTrigger("Hide");
        camAnim.SetTrigger("EndCutscene");
        yield return new WaitForSeconds(1f);
        camAnim.enabled = false;
        skipButton.enabled = false;
    }

    IEnumerator CutsceneSkip()
    {
        blackBars.SetTrigger("Hide");
        camAnim.SetTrigger("EndCutscene");
        yield return new WaitForSeconds(1f);
        skipButton.enabled = false;
        camAnim.enabled = false;
        UI.enabled = true;
        UI2.enabled = true;
    }

    public void SkipCutscene()
    {
        StartCoroutine(CutsceneSkip());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
