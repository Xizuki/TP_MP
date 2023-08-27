using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    public int renderQueue = 3002;
    // Start is called before the first frame update

    private void OnValidate()
    {
        //GetComponent<MeshRenderer>().material.renderQueue = renderQueue;
    }
    void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().material.renderQueue = renderQueue;
        if (GetComponent<MeshRenderer>() != null)  
            GetComponent<MeshRenderer>().material.renderQueue = renderQueue ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
