using UnityEngine;

public class AutoScaleMaterialTiling : MonoBehaviour
{
    public string materialPropertyName = "_MainTex"; // Replace with your material property name
    private Material material;
    private Renderer rendererComponent;

    private void Start()
    {
        // Get the Renderer component
        rendererComponent = GetComponent<Renderer>();

        if (rendererComponent == null)
        {
            Debug.LogWarning("Renderer component not found on the GameObject.");
            return;
        }

        // Get the material
        material = rendererComponent.material;

        if (material == null)
        {
            Debug.LogWarning("Material not found on the Renderer component.");
            return;
        }

        // Scale the material tiling based on the object's scale
        Vector3 scale = transform.localScale;
        material.SetTextureScale(materialPropertyName, new Vector2(scale.x, scale.z));
    }
}



