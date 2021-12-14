using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeinstantiater : MonoBehaviour
{

    // create values to further on in the script

    public GameObject sun;
    public GameObject sacrificialcube;
    GameObject[] cubes = new GameObject[128];
    public float maxScaling;
    public float radius = 3.14f;

    void Start()
    {
        for (int i = 0; i < 128; i++)                                                                                   //for loop that will instanciate the cubes for the audio visualiser
        {
            Quaternion rotate = Quaternion.AngleAxis((-2.8125f * i) + 90, Vector3.right);                               //setting the rotation angle at which the cubes will be instanciated appart from each other
            Vector3 direction = rotate * Vector3.up;                                                                    //setting the direction in which the cubes will be instanciated
            Vector3 position = (direction * radius) + sun.transform.position;                                           //setting the position at which the cubes will be instanciated


            GameObject instanceCube = (GameObject)Instantiate(sacrificialcube, position, rotate);                       //command to actually instanciate the cubes
            instanceCube.transform.parent = this.transform;                                                             //setting all the instanciated cubes as children of a single object
            
            instanceCube.name = "sacrificialcube" + i;                                                                  //naming the instanciated cubes
            cubes[i] = instanceCube;                                                                                    //setting the for value to be equal to the ube value, so the right amount gets instanciated
        }
    }

    void Update()
    {
        for (int i = 0; i < 128; i++)                                                                                   //for loop that changes the cube scaling individually
        {
            if (cubes != null)
            {
                
                cubes[i].transform.localScale = new Vector3( 10, audioScript.audioBlocks[i] * maxScaling + 2, 10 );     //setting the cube scale, to be equal to a value from the audioScript that fetches FFT values
            }
        }
    }
     public void scaling(float scaling)
    {
        maxScaling = 500 * scaling;                                                                                     //public function that allows the slidebar to affect the scaling
    }

}
