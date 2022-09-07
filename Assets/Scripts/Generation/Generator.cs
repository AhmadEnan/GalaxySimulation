using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float[,] CreateNoiseMap(int mapwidth, int mapheight, float scale) 
    {
        // error check
        scale = Mathf.Clamp(scale, 0.00001f, Mathf.Infinity);

        // construct our map based on given input
        float[,] noiseMap = new float[mapwidth, mapheight];

        // generate the map using perlin noise
        for (int y = 0; y < mapheight; y++) 
        {
            for (int x = 0; x < mapwidth; x++)
            {
                float _x = x / scale, _y = y / scale;
                noiseMap[x, y] = Mathf.PerlinNoise(_x, _y);
            }
        }

        return noiseMap;
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
