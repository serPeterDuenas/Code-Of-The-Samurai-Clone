using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager thisInstance { get; private set; }


    [SerializeField] private int playerLives = 3;
    public static int currentPlayerLives = 3;
    private static bool hasInit = false;
    //[SerializeField] private LevelLoader currentLevel;
    [SerializeField] private string mainMenuSceneName;
    public static bool playerDead = false;
    public static bool goingToNextScene = false;

    //private string scene;


    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip stageOneMusic;
    [SerializeField] private AudioClip stageTwoMusic;
    [SerializeField] private AudioClip stageThreeMusic;
    [SerializeField] private AudioClip bossOneMusic;
    [SerializeField] private AudioClip bossTwoMusic;
    [SerializeField] private AudioClip bossThreeMusic;

    private int currentStage = 0;


    public void UpdateStage(int getStage)
    {
        currentStage = getStage;
    }


    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("PLayert lives Gamemanager " + playerLives);




        if (!hasInit)
        {
            currentPlayerLives = playerLives;
        }
        else if (goingToNextScene)
        {
            goingToNextScene = false;
            LevelManager.thisInstance.CheckStage();
            return;
        }
        else
        {
            currentPlayerLives--;
        }
        //Debug.Log(currentPlayerLives);

        if(thisInstance == null)
        {
            thisInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(thisInstance != this)
        {
            Destroy(gameObject);
            return;
        }

    }




    // Update is called once per frame
    void Update()
    {
        switch(currentStage)
        {
            case 0:
                MusicManager.thisInstance.PlayMusic(mainMenuMusic);
                //MusicManager.thisInstance.soundPlayed = true;
                break;
            case 1:
                MusicManager.thisInstance.PlayMusic(stageOneMusic);
                break;
            case 2:
                MusicManager.thisInstance.PlayMusic(stageTwoMusic);
                break;
            case 3:
                MusicManager.thisInstance.PlayMusic(stageThreeMusic);
                break;
            case 4:
                MusicManager.thisInstance.PlayMusic(bossOneMusic);
                break;
            case 5:
                MusicManager.thisInstance.PlayMusic(bossTwoMusic);
                break;
            case 6:
                MusicManager.thisInstance.PlayMusic(bossThreeMusic);
                break;
            default:
                MusicManager.thisInstance.PlayMusic(mainMenuMusic);
                break;
        }


        if (currentPlayerLives == 0 && playerDead)
        {
            //LoadMenu();
            currentPlayerLives = playerLives;

            LoadMenu();
            playerDead = false;
        }
        else
            return;

        //Debug.Log(playerDead);
    }


    public void ResetScene()
    {
        hasInit = true;
        
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
        currentStage = 0;
    }


    private void PlayMusic()
    {

    }
}
