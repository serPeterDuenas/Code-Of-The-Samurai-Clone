using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int totalLives;
    public int currentLives;
    private LivesManager thisManager;
    private DontDestroyUI destroyUI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float waitOnSecondsMenu;


    private Text playerLivesText;
    [SerializeField] private string mainMenuScreenName;


    
 
    // Start is called before the first frame update
    void Start()
    {
        playerLivesText = GetComponent<Text>();
        currentLives = totalLives;
        
        destroyUI = GetComponentInParent<DontDestroyUI>();

    }

    private void Awake()
    {

    }


  
    public void UpdateLives(int takeAwayLife)
    {
        currentLives -= takeAwayLife;

        if (currentLives == 0) 
        {
            gameOverScreen.SetActive(true);
            SceneManager.LoadScene(mainMenuScreenName);
            Destroy(transform.parent.gameObject);
        }
    }    

    // Update is called once per frame
    void Update()
    {
        //getCurrentScene = GameObject.FindWithTag("Level");
        playerLivesText.text = "Current lives: " + currentLives;

        if (gameOverScreen.activeInHierarchy)
        {
            waitOnSecondsMenu -= Time.deltaTime;
        }

        if (waitOnSecondsMenu < 0)
        {
            gameOverScreen.SetActive(false);
        }


    }
}
