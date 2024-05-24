using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private float waitOnSecondsMenu;
    //[SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverMusic;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        waitOnSecondsMenu -= Time.deltaTime;

        if (waitOnSecondsMenu <= 0)
        {
            GameManager.playerDead = true;
            //gameOverScreen.SetActive(false);
            LoadMenu();

        }

    }


    private void PlayMusic()
    {
        MusicManager.thisInstance.StopMusic();
        MusicManager.thisInstance.PlayMusic(gameOverMusic);
    }

    private void LoadMenu()
    {
        GameManager.thisInstance.ResetLives();
        SceneManager.LoadScene("MainMenu");
        LevelManager.thisInstance.CheckStage();
        ExitDoor.currentStage = 1;


    }
}
