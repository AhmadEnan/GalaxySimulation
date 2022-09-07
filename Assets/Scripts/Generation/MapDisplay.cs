using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    // Generator g;

    [SerializeField]
    public Renderer DisplayPlane;

    public int Width = 128;
    public int Height = 128;
    public int Seed = 69;

    Lehmer.Random randNumGen;
    void DrawNoiseMap() 
    {

        Texture2D mapTexture = new Texture2D(Width, Height);
        
        Color[] colorMap = new Color[Width * Height];

        for (int y = 0; y < Height; y++) 
        {
            for (int x = 0; x < Width; x++) 
            {
                float num = (float)randNumGen.NextDouble();
                // Color c = num == 0 ? Color.black : Color.white;
                // colorMap[y * Width + x] = c;
                colorMap[y * Width + x] = Color.Lerp(Color.black, Color.white, num);
            }
        }

        // int width = noiseMap.GetLength(0);
        // int height = noiseMap.GetLength(1);
        // 
        // Texture2D tex = new Texture2D(width, height);
        // 
        // Color[] colorMap = new Color[width * height];
        // for (int y = 0; y < height; y++) 
        // {
        //     for (int x = 0; x < width; x++) 
        //     {
        //         colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
        //     }
        // }
        // 
        mapTexture.SetPixels(colorMap);
        mapTexture.Apply();
        DisplayPlane.sharedMaterial.mainTexture = mapTexture;
        DisplayPlane.transform.localScale = new Vector3(Width, 1, Height);
    }

    public void DrawMap() 
    {
        // float[,] map = g.CreateNoiseMap(Width, Height, scale);
        DrawNoiseMap();
    }

    void Start() 
    {
        // g = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        randNumGen = new Lehmer.Random(Seed);
        DrawNoiseMap();
    }
}
