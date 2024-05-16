using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private bool isNextStage = false;


    [SerializeField] private string scene;
    //[SerializeField] private bool startNextStage = false;
    public static int currentStage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            LoadNextScene();
        }    
    }


    private void LoadNextScene()
    {
        GameManager.goingToNextScene = true;
        SceneManager.LoadScene(scene);

        if(isNextStage)
        {
            currentStage = currentStage + 1;
            LevelManager.thisInstance.ChangeStage(currentStage);
            LevelManager.thisInstance.PlayStageMusic();
            isNextStage = false;
        }    


        //LevelManager.thisInstance.CheckStage(updateStage);
        //SceneManager.LoadScene(currentLevelCount + 1);

        //currentLevelCount++;
    }




}
