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
    [SerializeField] private string currentScene;
    //private string scene;


    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("PLayert lives Gamemanager " + playerLives);



        if (!hasInit)
        {
            currentPlayerLives = playerLives;
            //currentPlayerLives--;
        }
        else if (goingToNextScene)
        {
            goingToNextScene = false;
            LevelManager.thisInstance.CheckStage();
            return;
        }
        else
        {
            return;
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
        currentPlayerLives--;
        
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        currentScene = scene.name;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
        LevelManager.thisInstance.CheckStage();
        ExitDoor.currentStage = 1;

        var scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
    }


    private void PlayMusic()
    {

    }
}
