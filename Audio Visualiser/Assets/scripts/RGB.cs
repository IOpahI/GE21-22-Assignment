using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    //declaring materials to switch then when swapping colour modes

    public Material normalColour;
    public Material BrightColour;
    public static MeshRenderer myMR;
    public static bool BSM;
    private float colorval;


    
    void Start()
    {
        myMR = GetComponentInChildren<MeshRenderer>();                                  //making the meshRenderer in each childed cube actually grab the respective component
    }

    void Update()
    {
        normalColour.color = Color.HSVToRGB(colorval, 1, 1);                            //setting a HSV value, to cycle through colour, since only the H value has to be changed, making cycling easier
        colorval += Time.deltaTime * terrainGeneration.speed * 0.5f;                    //setting the colourvalue to change with time, as well as the speed at which the terrain is going (times 0.5 for a better feel

        if (colorval >= 1)                                                              //setting the H value to loop all the floats from 0-1
        {
            colorval = 0;
        }

        if (BSM == true)
        {
            myMR = GetComponentInChildren<MeshRenderer>();                              //grabbing the meshRenderer in each child again to set it to a white colour if to toggle buttong for dark mode is set to true
            myMR.material = BrightColour;
        }
        else
        {
            myMR = GetComponentInChildren<MeshRenderer>();                              //making sure the material on the instanciated cubes actually gets updated along with the H value that the material is holding
            myMR.material = normalColour;
        }
    }

    public void ColourChange()
    {
        BSM = !BSM;                                                                     //setting a swap for the dark mode toggle
    }

}
