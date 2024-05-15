using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager thisInstance { get; private set; }
    private AudioSource source;
    public static bool soundPlayed = false;



    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if (thisInstance == null)
        {
            thisInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (thisInstance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayMusic(AudioClip _sound)
    {
        if(source.isPlaying)
        {
            return;
        }
        else
        {
            source.PlayOneShot(_sound);
        }
       
    }

    public void StopMusic(AudioClip _sound)
    {
        if (source.isPlaying)
        {
            return;
        }
        else
        {
            source.Stop();
        }

    }
}
