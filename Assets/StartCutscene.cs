using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public Animator camAnim;
    public Canvas UI;
    public Canvas UI2;

    public Animator blackBars;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeWait());
    }

    IEnumerator timeWait()
    {
        UI.enabled = false;
        UI2.enabled = false;
        blackBars.enabled = true;
        blackBars.SetTrigger("Show");
        yield return new WaitForSeconds(4.5f);
        UI.enabled = true;
        UI2.enabled = true;
        blackBars.SetTrigger("Hide");
        yield return new WaitForSeconds(1f);
        camAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
