using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int totalLives;
    private int currentLives;
    private LivesManager thisManager;


    private Text playerLivesText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private string mainMenuScreenName;
    [SerializeField] private float waitOnSecondsMenu;


    //[SerializeField] private GameObject getCurrentScene;
 
    // Start is called before the first frame update
    void Start()
    {
        playerLivesText = GetComponent<Text>();
        currentLives = totalLives;
        //getCurrentScene = GameObject.FindWithTag("Level");

    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //if(thisManager == null) 
        //{
         //   thisManager = this;
        //}
        //else
        //{
        //    Object.Destroy(gameObject);
        //}
    }


    public void UpdateLives(int takeAwayLife)
    {
        currentLives -= takeAwayLife;
        //getCurrentScene = GameObject.FindWithTag("Level");

        if (currentLives == 0) 
        {
            Debug.Log("Player lives = 0");
            gameOverScreen.SetActive(true);
            //getCurrentScene.SetActive(false);
        }
    }    

    // Update is called once per frame
    void Update()
    {
        //getCurrentScene = GameObject.FindWithTag("Level");
        playerLivesText.text = "Current lives: " + currentLives;
    }
}
