using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int currentStage = 0;
    public static LevelManager thisInstance { get; set; }
    private bool isPlaying = false;


    private void Awake()
    {
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

        CheckStage();
    }


    public void CheckStage()
    {
        var scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);

        if (scene.name == "MainMenu")
        {
           currentStage = 0;
        }
        else if (scene.name == "Level1-1")
        {
            currentStage = 1;
        }
        else if (scene.name == "Boss1")
        {
            currentStage = 2;
        }
        else if (scene.name == "Level2-1")
        {
           currentStage = 3;
        }
        else if (scene.name == "Boss2")
        {
            currentStage = 4;
        }
        else if (scene.name == "Level3-1")
        {
            currentStage = 5;
        }
        else if (scene.name == "Boss3")
        {
            currentStage = 6;
        }
        else
            return;

        //Debug.Log(currentStage);
        //Debug.Log(scene.name);

        PlayStageMusic();
    }



    public void ChangeStage(int stage)
    {
        var scene = SceneManager.GetActiveScene();


        Debug.Log(currentStage);
        Debug.Log(scene.name);

        currentStage = stage;

        //PlayStageMusic();
    }


    public void PlayStageMusic()
    {
        MusicManager.thisInstance.StopMusic();
        MusicManager.thisInstance.PlayMusic(currentStage);

        var scene = SceneManager.GetActiveScene();
        //Debug.Log(currentStage);
        //Debug.Log(scene.name);
    }    
}
