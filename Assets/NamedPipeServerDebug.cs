using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class NamedPipeServerDebug : MonoBehaviour
{
    public NamedPipeServer namedPipeServer;

    public TMP_Text text;

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        namedPipeServer = GetComponent<NamedPipeServer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (namedPipeServer.lastestLine.Contains("True"))
            text.text = "TRUE";
        else if (namedPipeServer.lastestLine.Contains("False"))
            text.text = "FALSE";

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(parent.gameObject.activeInHierarchy)
                parent.gameObject.SetActive(false);
            else
                parent.gameObject.SetActive(true);
        }
    }
}
