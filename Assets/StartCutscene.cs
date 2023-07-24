using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeWait());
    }

    IEnumerator timeWait()
    {
        yield return new WaitForSeconds(5.5f);
        camAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
