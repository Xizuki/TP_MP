using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xi_TextureAutoTiling : MonoBehaviour
{
    public Material mat;
    public float scale;
    private void OnValidate()
    {
        mat.mainTextureScale = new Vector2(transform.localScale.x , transform.localScale.y) * scale;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
