using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager thisInstance;
    [SerializeField] private int playerLives = 3;
    public static int currentPlayerLives = 3;
    private static bool hasInit = false;
    //[SerializeField] private LevelLoader currentLevel;
    [SerializeField] private string mainMenuSceneName;
    public static bool playerDead = false;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("PLayert lives Gamemanager " + playerLives);
       
        


        if(!hasInit) 
        {
            currentPlayerLives = playerLives;
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
        if(currentPlayerLives == 0 && playerDead)
        {
            //LoadMenu();
            currentPlayerLives = playerLives;
            
            LoadMenu();
            playerDead = false;
        }

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

    }
}
