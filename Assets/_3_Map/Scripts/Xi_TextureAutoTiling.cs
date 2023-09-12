using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Xi_TextureAutoTiling : MonoBehaviour
{
    public bool zAxisInclude;
    public Material sourceMat;
    public Material matInstance;
    public float scale;
    private void OnValidate()
    {
        if (matInstance == null) { return; }

        if(!zAxisInclude)
            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
        else
            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z * (transform.localScale.z/ transform.localScale.y)) * scale;

    }

    [ContextMenu("Generate Material Instance")]
    public void GenerateMatInstance()
    {
        Renderer renderer = GetComponent<Renderer>();
       // sourceMat = renderer.GetMaterials();

        if(matInstance!=null)
        {
            DestroyImmediate(matInstance);
        }

        matInstance = Instantiate(sourceMat);
        renderer.material = matInstance;

        if (!zAxisInclude)
            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
        else
            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z * (transform.localScale.z / transform.localScale.y)) * scale;
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
