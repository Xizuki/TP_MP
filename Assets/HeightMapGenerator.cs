using UnityEngine;

public class HeightMapGenerator : MonoBehaviour
{
    public int textureWidth = 512;
    public int textureHeight = 512;
    public string textureSavePath = "Assets/ApiXizuki/HeightMap.png";

    private MeshRenderer meshRenderer;
    private Mesh mesh;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().sharedMesh;
    }

    [ContextMenu("Generate")]
    public void GenerateAndSaveHeightMap()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().sharedMesh;
        Texture2D heightMapTexture = GenerateHeightMapTexture();
        SaveTextureAsPNG(heightMapTexture);
    }

    private Texture2D GenerateHeightMapTexture()
    {
        Vector3[] vertices = mesh.vertices;
        int vertexCount = vertices.Length;

        // Calculate min and max heights for normalization
        float minHeight = float.MaxValue;
        float maxHeight = float.MinValue;
        for (int i = 0; i < vertexCount; i++)
        {
            float vertexHeight = vertices[i].y;
            minHeight = Mathf.Min(minHeight, vertexHeight);
            maxHeight = Mathf.Max(maxHeight, vertexHeight);
        }

        // Create a new texture
        Texture2D heightMapTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RFloat, false);

        // Assign height values to the texture
        for (int y = 0; y < textureHeight; y++)
        {
            for (int x = 0; x < textureWidth; x++)
            {
                // Normalize texture coordinates
                float u = (float)x / (textureWidth - 1);
                float v = (float)y / (textureHeight - 1);

                // Convert texture coordinates to mesh vertex index
                int vertexIndexX = Mathf.FloorToInt(u * (mesh.vertexCount - 1));
                int vertexIndexZ = Mathf.FloorToInt(v * (mesh.vertexCount - 1));
                int vertexIndex = vertexIndexX + vertexIndexZ * Mathf.FloorToInt(Mathf.Sqrt(vertexCount));

                // Get vertex height and normalize it to range [0, 1]
                float normalizedHeight = Mathf.InverseLerp(minHeight, maxHeight, vertices[vertexIndex].y);

                // Set the pixel value in the height map
                heightMapTexture.SetPixel(x, y, new Color(normalizedHeight, normalizedHeight, normalizedHeight));
            }
        }

        // Apply changes and return the height map texture
        heightMapTexture.Apply();
        return heightMapTexture;
    }

    private void SaveTextureAsPNG(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(textureSavePath, bytes);
        Debug.Log("Height map texture saved at: " + textureSavePath);
    }
}