using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager thisInstance { get; private set; }



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
    }


    public void CheckStage()
    {
        var scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            GameManager.thisInstance.UpdateStage(0);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Level1-1")
        {
            GameManager.thisInstance.UpdateStage(1);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Level2-1")
        {
            GameManager.thisInstance.UpdateStage(2);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Level3-1")
        {
            GameManager.thisInstance.UpdateStage(3);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Boss1")
        {
            GameManager.thisInstance.UpdateStage(4);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Boss2")
        {
            GameManager.thisInstance.UpdateStage(5);
            MusicManager.soundPlayed = false;
        }
        else if (scene.name == "Boss3")
        {
            GameManager.thisInstance.UpdateStage(6);
            MusicManager.soundPlayed = false;
        }
        else
            return;
    }
}
