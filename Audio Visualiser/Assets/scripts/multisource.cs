using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class multisource : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip Song1, Song2, Song3, Song4, Song5, Song6;
    
    


    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }


    void Update()
    {
         //if(isPlaying=true && 
        {

        }
    }

    public void HandleInputData(int TrackNumber)
    {
        if (TrackNumber == 0)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song1);
        }
        if (TrackNumber == 1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song2);
        }
        if (TrackNumber == 2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song3);
        }
        if (TrackNumber == 3)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song4);
        }
        if (TrackNumber == 4)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song5);
        }
        if (TrackNumber == 5)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song6);
        }

    }

}
