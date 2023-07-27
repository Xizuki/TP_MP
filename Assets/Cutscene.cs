using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(WaitTime());
        
    }

    IEnumerator WaitTime()
    {
        print("Cutscene Ongoing");
        yield return new WaitForSeconds(5.5f);
        animator.enabled = false;

    }
}
