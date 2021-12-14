using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);               //setting the camera to look at a public target(the sun)
    }
}
