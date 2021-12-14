using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    public ParticleSystem topLeft, topRight, Middle;
    private float speed = 10f;

    
    void Update()
    {
        topLeft.startSpeed = speed;                 //setting the particle speed equal to a custom value
        topRight.startSpeed = speed;
        Middle.startSpeed = speed;
    }

    public void speedchange(float newSpeed)         //public function to handle particle speed
    {
        speed = speed * newSpeed;                   //setting the speed to be affected by the slidebar speed, that also handles rgb speed and terrain speed
        if (speed >= 20)
        {
            speed = 20f;
        }
    }
}
