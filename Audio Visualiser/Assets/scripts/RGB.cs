using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    public Material normalColour;
    public Material BrightColour;
    public static MeshRenderer myMR;
    public static bool BSM;
    private float colorval;


    
    void Start()
    {
        myMR = GetComponentInChildren<MeshRenderer>();
        //normalColour.SetColor("normalColour", Color.HSVToRGB(colorval, 1, 1));

    }

    void Update()
    {
        normalColour.color = Color.HSVToRGB(colorval, 1, 1);
        colorval += Time.deltaTime * terrainGeneration.speed;

        if (colorval >= 1)
        {
            colorval = 0;
        }

        if (BSM == true)
        {
            myMR = GetComponentInChildren<MeshRenderer>();
            myMR.material = BrightColour;
            Debug.Log("true");
        }
        else
        {
            myMR = GetComponentInChildren<MeshRenderer>();
            myMR.material = normalColour;
            Debug.Log(colorval);
        }



    }

    public void ColourChange()
    {
        BSM = !BSM;
    }

}
