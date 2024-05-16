using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager thisInstance { get; private set; }
    private AudioSource source;
    [SerializeField] private AudioClip[] clips;
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

    public void PlayMusic(int currentStage)
    {
        if (source.isPlaying)
        {
            soundPlayed = true;
            return;
        }
        else
        {
            source.PlayOneShot(clips[currentStage]);
            source.loop = true;
        }
       
    }

    public void StopMusic()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
        else
        {
            return;
        }

    }
}
