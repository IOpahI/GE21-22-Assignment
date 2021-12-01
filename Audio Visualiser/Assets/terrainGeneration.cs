using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGeneration : MonoBehaviour
{

    // create values to use for vector3 when adjusting terrain size
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    public float xOffset = 100f;
    public float yOffset = 100f;


    void Start()
    {
        xOffset = Random.Range(0f, 999999f);
        yOffset = Random.Range(0f, 999999f);
    }

    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //taking value form the below terrain data that is being generated and passing into the current terrain
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width * 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x< width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoordinate = (float)x / width * scale;
        float yCoordiante = (float)y / height * scale;

        return Mathf.PerlinNoise(xCoordinate, yCoordiante);
    }

}
