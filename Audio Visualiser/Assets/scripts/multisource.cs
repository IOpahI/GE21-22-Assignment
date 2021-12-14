using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class multisource : MonoBehaviour
{

    public AudioSource audioSource;                                                             
    public AudioClip Song1, Song2, Song3, Song4, Song5, Song6;                                  //public song pool




    void Start()
    {
        audioSource.GetComponent<AudioSource>();                                                //making the audiosource be able to play the songs that the script will determine
    }

    public void HandleInputData(int TrackNumber)                                                // public function to allow the dropdown bar to select a tracknumber
    {
        if (TrackNumber == 0)                                                                   //each tracknumber represents a different song. Track number 0 holds a "--Please Select--" field
        {
            audioSource.Stop();
           
        }
        if (TrackNumber == 1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song1);
        }
        if (TrackNumber == 2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song2);
        }
        if (TrackNumber == 3)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song3);
        }
        if (TrackNumber == 4)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song4);
        }
        if (TrackNumber == 5)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song5);
        }
        if (TrackNumber == 6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song6);
        }

    }

    public void pauseButton()
    {
        audioSource.Pause();                                                    //telling the script to pause the song that is being played when pressing the pause button
    }

    public void resumeButton()
    {
        audioSource.UnPause();                                                  //--^-- in relation to resuming the music
    }
}
