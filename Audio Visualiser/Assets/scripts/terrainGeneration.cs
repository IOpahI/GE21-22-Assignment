using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class terrainGeneration : MonoBehaviour
{

    // create values to use for math further on in the script
    public int depth = 4;
    public int width = 256;
    public int length = 256;
    public float scale = 20f;
    public float xOffset = 100f;
    public float yOffset = 100f;
    public static float speed = 2.5f;


    void Start()
    {
        xOffset = Random.Range(0f, 9999f);                         //offsets in order to randomize the map when launching and adding a movement effect
        yOffset = Random.Range(0f, 9999f);
    }

    void Update()
    {

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //taking value form the below terrain data that is being generated and passing into the current terrain

        yOffset += Time.deltaTime * speed;                          //adding the "movement effect" of the project

        
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width * 1;                //adjusting the terrains heightmap to the be in order with the rest of the map
        terrainData.size = new Vector3(width, depth, length);       //setting terrain size
        terrainData.SetHeights(0, 0, GenerateHeights());            //setting terrain height values -- with a bew function that generats these height values
        return terrainData;                                         //returning terraindata values
    }

    float[,] GenerateHeights()                                      //using a float array, to fill the previous setHeights argument
    {
        float[,] heights = new float[width, length];                
        for (int x = 0; x< width; x++)
        {
            for(int y = 0; y < length; y++)                         //nested for loop that cycles through the maps length and width
            {
                heights[x, y] = CalculateHeight(x, y);              //setting each coordinate and using a new float to calculate those positions
            }
        }

        return heights;                                             //return heights value
    }

    float CalculateHeight(int x, int y)                             //new float to calculate each coordinate
    {
        float xCoordinate = (float)x / width * scale + xOffset;     //calculating x & y for each coordinate, making them float values
        float yCoordiante = (float)y / length * scale + yOffset;

        return Mathf.PerlinNoise(xCoordinate, yCoordiante);         //using perlin noise for pseudo-random generation
    }

    public void Scaling (float newScale)
    {
        scale = newScale;                                           //setting terrain scale to match the slidebar value
    }

    public void SpeedChange (float newSpeed)
    {
        speed = newSpeed;                                           //setting terrain speed to math slidebar value
    }
}
