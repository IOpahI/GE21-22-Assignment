using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainfollow : MonoBehaviour
{

    void Update()
    {
        Vector3 myPos = transform.position; //grabbing the curent vector3 of the camera

        myPos.y = Terrain.activeTerrain.SampleHeight(myPos); // grabbing the height of the terrain under the camera
        myPos.y += 4;                                        // adding onto the terrain height

        transform.position = myPos;                          // changing camera height to be updated to the new value
    }
}
