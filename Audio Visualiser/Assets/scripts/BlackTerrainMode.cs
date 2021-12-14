using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTerrainMode : MonoBehaviour
{
    //declaring materials to switch then when swapping colour modes

    public Terrain terrain;
    public Material normalFloor;
    public Material BlackFloor;

    void Start()
    {
        terrain = GetComponent<Terrain>();                                          //making the meshRenderer actually grab the respective component
    }

    public void FloorChange(bool DFM)                                               //public function to make it accessible by the toggle button
    {
        if (DFM == true)                                                            //if statement, saying that if the toggle is turned on, then show off dark mode, otherwise show the normal colourmode
        {
            terrain.materialTemplate = BlackFloor;
        }
        else
        {
            terrain.materialTemplate = normalFloor;
        }
    }
}
