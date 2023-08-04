using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xi_TextureAutoTiling : MonoBehaviour
{
    public Material sourceMat;
    public Material matInstance;
    public float scale;
    private void OnValidate()
    {
        //Texture2D newTextureInstance = new Texture2D(mat.mainTexture.width, mat.mainTexture.height);

        //newTextureInstance.SetPixels(((Texture2D)mat.mainTexture).GetPixels());

        //textureInstance = newTextureInstance;

        //mat.mainTexture = textureInstance;

        if (matInstance == sourceMat || matInstance == null)
        {

            Renderer renderer = GetComponent<Renderer>();
            sourceMat = renderer.material;

            matInstance = Instantiate(sourceMat);
            renderer.material = matInstance;

            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
        }
        else
        {
            matInstance.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
        }
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
