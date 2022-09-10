using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    [SerializeField] private uint noiseMapWidth = 128;
    [SerializeField] private uint noiseMapHeight = 128;
    [SerializeField] private uint noiseMapSeed = 6969;

    public int NoiseMapWidth
    {
        get { return (int)noiseMapWidth; }
        set { noiseMapWidth = (uint)value; }
    }
    public int NoiseMapHeight
    {
        get { return (int)noiseMapHeight; }
        set { noiseMapHeight = (uint)value; }
    }
    public int NoiseMapSeed
    {
        get { return (int)noiseMapSeed; }
        set { noiseMapSeed = (uint)value; }
    }

    Lehmer.Random randNumGen;

    internal float[,] GenerateNoiseMap(uint width, uint height, uint seed) 
    {
        float[,] noiseMap = new float[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                uint nSeed = (uint)(y << 16 | x) * (uint)(seed);
                // Debug.Log("Seed is : " + randNumGen.Seed);
                // randNumGen.Seed = (uint)Seed;
                float num = (float)randNumGen.GetNextInt(nSeed, 0, 20);
                // Color c = num == 0 ? Color.black : Color.white;
                // colorMap[y * Width + x] = c;
                // colorMap[y * Width + x] = Color.Lerp(Color.white, Color.black, num);
                noiseMap[x, y] = num;
            }
        }

        return noiseMap;
    }

    public float[,] GetNoiseMap() 
    {
        return GenerateNoiseMap(noiseMapWidth, noiseMapHeight, noiseMapSeed);
    }

    void Awake()
    {
        randNumGen = new Lehmer.Random(noiseMapSeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
