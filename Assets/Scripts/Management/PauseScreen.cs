using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public static bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }



    private void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        pauseScreen.SetActive(false);
        isPaused = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
