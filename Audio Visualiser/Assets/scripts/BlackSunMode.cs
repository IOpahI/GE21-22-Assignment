using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSunMode : MonoBehaviour
{

   

    public Material normalSun;
    public Material BlackSun;
    public MeshRenderer myMR;


   
    void Start()
    {
        myMR = GetComponent<MeshRenderer>();
    }

   
    void Update()
    {
        
    }

    public void SunChange(bool BSM)
    {
        if (BSM == true)
        {
            myMR.material = BlackSun;
        }
        else
        {
            myMR.material = normalSun;
        }
    }
}
