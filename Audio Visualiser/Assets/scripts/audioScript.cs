using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    AudioListener audioListener;
    public static float[] audioBlocks = new float[128];                                                 //array that will hold FFT values
 

    void Start()
    {
        audioListener = GetComponent<AudioListener>();                                                  //making the audioListener be able to listen to the audio
    }


    void Update()
    {
        AudioListener.GetSpectrumData(audioBlocks, 0, FFTWindow.Hamming);                               //telling the audio listener to fetch frequency values, and feed them into the audioBlocks array
    }
}
