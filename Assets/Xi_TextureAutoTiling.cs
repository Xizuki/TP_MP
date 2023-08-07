using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Axis { xy, yz, xz };

public class Xi_TextureAutoTiling : MonoBehaviour
{
    public Axis axis;
    public Material sourceMat;
    public Material matInstance;
    public float scale;
    private void OnValidate()
    {
        //Texture2D newTextureInstance = new Texture2D(mat.mainTexture.width, mat.mainTexture.height);

        //newTextureInstance.SetPixels(((Texture2D)mat.mainTexture).GetPixels());

        //textureInstance = newTextureInstance;

        //mat.mainTexture = textureInstance;

        if(axis == Axis.xy)
        {

        }


        matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z) * scale;

    }

    [ContextMenu("Generate Material Instance")]
    public void GenerateMatInstance()
    {
        Renderer renderer = GetComponent<Renderer>();
       // sourceMat = renderer.GetMaterials();

        matInstance = Instantiate(sourceMat);
        renderer.material = matInstance;

        matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z) * scale;
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
