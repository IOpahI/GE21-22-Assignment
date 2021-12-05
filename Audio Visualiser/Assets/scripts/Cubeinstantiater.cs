using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeinstantiater : MonoBehaviour
{
    public GameObject sun;
    public GameObject sacrificialcube;
    GameObject[] cubes = new GameObject[128];
    public float maxScaling;
    public float radius = 3.14f;
  





    void Start()
    {




        for (int i = 0; i < 128; i++)
        {
            Quaternion rotate = Quaternion.AngleAxis((-2.8125f * i) + 90, Vector3.right);
            Vector3 direction = rotate * Vector3.up;
            Vector3 position = (direction * radius) + sun.transform.position;


         

            GameObject instanceCube = (GameObject)Instantiate(sacrificialcube, position, rotate);
            instanceCube.transform.parent = this.transform;
            
            instanceCube.name = "sacrificialcube" + i;
            cubes[i] = instanceCube;
        }
    }

    void Update()
    {
        for (int i = 0; i < 128; i++)
        {
            if (cubes != null)
            {
                
                cubes[i].transform.localScale = new Vector3( 10, audioScript.audioBlocks[i] * maxScaling + 2, 10 );
            }
        }
    }
     public void scaling(float scaling)
    {
        maxScaling = 500 * scaling;
    }

}
