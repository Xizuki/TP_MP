using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XI_TextureParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Generate Material Instance")]
    public void GenerateAllMaterialInstance()
    {
        Xi_TextureAutoTiling[] scripts = GameObject.FindObjectsOfType<Xi_TextureAutoTiling>();

        foreach(Xi_TextureAutoTiling s in scripts)
        {
            s.GenerateMatInstance();
        }
    }
}
