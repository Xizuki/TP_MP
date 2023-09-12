using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Xi_QuadCubeTextureAutoTiling : MonoBehaviour
{
    public Material sourceMat;
    public Material[] matInstances = new Material[3];
    public Renderer[] quadRenderersX;
    public Renderer[] quadRenderersY;
    public Renderer[] quadRenderersZ;
    public float scale;

    public Transform[] quadsX;
    public Transform[] quadsY;
    public Transform[] quadsZ;

    private void OnValidate()
    {

        matInstances[0].mainTextureScale = new Vector2(transform.localScale.z, transform.localScale.x) * scale;
        matInstances[1].mainTextureScale = new Vector2(transform.localScale.y, transform.localScale.z) * scale;
        matInstances[2].mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
    }

    [ContextMenu("Generate Material Instance")]
    public void GenerateMatInstance()
    {
        for(int i =0; i < quadRenderersX.Length; i++)
        {

        }
        Renderer renderer = GetComponent<Renderer>();
        // sourceMat = renderer.GetMaterials();

        matInstances[0] = Instantiate(sourceMat);
        matInstances[1] = Instantiate(sourceMat);
        matInstances[2] = Instantiate(sourceMat);
        quadRenderersX[0].material = matInstances[0];
        quadRenderersX[1].material = matInstances[0];
        quadRenderersY[0].material = matInstances[1];
        quadRenderersY[1].material = matInstances[1];
        quadRenderersZ[0].material = matInstances[2];
        quadRenderersZ[1].material = matInstances[2];

        matInstances[0].mainTextureScale = new Vector2(transform.localScale.z, transform.localScale.x) * scale;
        matInstances[1].mainTextureScale = new Vector2(transform.localScale.y, transform.localScale.z) * scale;
        matInstances[2].mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) * scale;
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
