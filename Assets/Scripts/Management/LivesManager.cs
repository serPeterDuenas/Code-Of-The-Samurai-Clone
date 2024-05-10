using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int totalLives;
    private int currentLives;

    private Text playerLivesText;
    [SerializeField] private GameObject gameOverScreen;
 
    // Start is called before the first frame update
    void Start()
    {
        playerLivesText = GetComponent<Text>();
        currentLives = totalLives;
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }


    public void UpdateLives(int takeAwayLife)
    {
        currentLives -= takeAwayLife;
    }    

    // Update is called once per frame
    void Update()
    {
        playerLivesText.text = "Current lives: " + currentLives;
    }
}
