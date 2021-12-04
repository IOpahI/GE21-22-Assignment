using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    AudioListener audioListener;
    public static float[] audioBlocks = new float[128];
    // Start is called before the first frame update
    void Start()
    {
        audioListener = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(audioBlocks, 0, FFTWindow.Hamming);
    }
}
