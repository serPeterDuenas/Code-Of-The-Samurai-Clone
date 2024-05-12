using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    //private GameManager gameManager;
    private int currentLives;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float waitOnSecondsMenu;
    //[SerializeField] private string mainMenuSceneName;

    private Text playerLivesText;
    


    
 
    // Start is called before the first frame update
    void Start()
    {
        playerLivesText = GetComponent<Text>();
        //gameOverScreen = FindObjectOfType<GameOver>
    }

    private void Awake()
    {
        currentLives = GameManager.currentPlayerLives;

    }


  
    public void UpdateLives()
    {
        currentLives--;
        //Debug.Log("Update player lives -- LivesManager");
        //Debug.Log("Current lives -- LivesManager: " + currentLives);
        
    }    


    // Update is called once per frame
    void Update()
    {

        if (currentLives == 0)
        {
            gameOverScreen.SetActive(true);
        }

        playerLivesText.text = "Current lives: " + currentLives;

        if (gameOverScreen.activeInHierarchy)
        {
            waitOnSecondsMenu -= Time.deltaTime;
           
        }

        if (waitOnSecondsMenu < 0)
        {
            gameOverScreen.SetActive(false);
            GameManager.playerDead = true;
            //Debug.Log(GameManager.playerDead);
            //Destroy(gameObject);
        }



    }
}
