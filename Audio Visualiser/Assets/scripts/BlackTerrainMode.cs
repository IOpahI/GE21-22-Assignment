using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTerrainMode : MonoBehaviour
{

    public Terrain terrain;
    public Material normalFloor;
    public Material BlackFloor;

    void Start()
    {
        terrain = GetComponent<Terrain>();
    }

    void Update()
    {
        
    }

    public void FloorChange(bool DFM)
    {
        if (DFM == true)
        {
            terrain.materialTemplate = BlackFloor;
        }
        else
        {
            terrain.materialTemplate = normalFloor;
        }
    }
}
