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
    [SerializeField] private GameObject thisScene;


    // Start is called before the first frame update
    void Awake()
    {
        thisScene = GameObject.FindGameObjectWithTag("Level");



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
        //if (thisScene == null)
        //{
        //    thisScene = GameObject.FindGameObjectWithTag("Level");
        //}
        //else
        //    return;


        if (currentPlayerLives <= 0 && playerDead)
        {
            //currentPlayerLives = playerLives;
            var scene = SceneManager.GetActiveScene();
            currentScene = scene.name;

            //LoadMenu();
            playerDead = false;
        }
        else
            return;
        
        //Debug.Log(playerDead);
    }


    public void ResetLives()
    {
        currentPlayerLives = playerLives;
    }


    public void ResetScene()
    {
        hasInit = true;
        currentPlayerLives--;
        //Debug.Log(GameManager.currentPlayerLives);
        //Debug.Log("Lives of player current");

        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        currentScene = scene.name;
    }


    //public void LoadMenu()
    //{
    //    SceneManager.LoadScene(mainMenuSceneName);
    //    LevelManager.thisInstance.CheckStage();
    //    ExitDoor.currentStage = 1;

    //    var scene = SceneManager.GetActiveScene();
    //    currentScene = scene.name;
    //}


    private void PlayMusic()
    {

    }
}
