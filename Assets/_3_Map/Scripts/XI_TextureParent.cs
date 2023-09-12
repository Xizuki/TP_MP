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
        
        {
             Component[] scripts = GetComponentsInChildren<Xi_TextureAutoTiling>();
            foreach (Component s in scripts)
            {
                s.GetComponent<Xi_TextureAutoTiling>().GenerateMatInstance();
            }
        }
        
    }
}
