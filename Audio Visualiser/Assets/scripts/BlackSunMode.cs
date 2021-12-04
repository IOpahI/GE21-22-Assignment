using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSunMode : MonoBehaviour
{

    //public bool BSM = false;

    public Material normalSun;
    public Material BlackSun;
    public MeshRenderer myMR;


    // Start is called before the first frame update
    void Start()
    {
        myMR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
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
