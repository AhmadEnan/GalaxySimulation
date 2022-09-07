using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    Generator g;

    [SerializeField]
    public Renderer DisplayPlane;

    public int Width = 128;
    public int Height = 128;
    public float scale = 2.3f;
    void DrawNoiseMap(float[,] noiseMap) 
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D tex = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        tex.SetPixels(colorMap);
        tex.Apply();
        DisplayPlane.sharedMaterial.mainTexture = tex;
        DisplayPlane.transform.localScale = new Vector3(width, 1, height);
    }

    public void DrawMap() 
    {
        float[,] map = g.CreateNoiseMap(Width, Height, scale);
        DrawNoiseMap(map);
    }

    void Start() 
    {
        g = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();

    }
}
