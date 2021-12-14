using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSunMode : MonoBehaviour
{

    //declaring materials to switch then when swapping colour modes

    public Material normalSun;
    public Material BlackSun;
    public MeshRenderer myMR;


   
    void Start()
    {
        myMR = GetComponent<MeshRenderer>();                                    //making the meshRenderer actually grab the respective component
    }

    public void SunChange(bool BSM)                                             //public function to make it accessible by the toggle button
    {
        if (BSM == true)                                                        //if statement, saying that if the toggle is turned on, then show off dark mode, otherwise show the normal colourmode
        {
            myMR.material = BlackSun;
        }
        else
        {
            myMR.material = normalSun;
        }
    }
}
