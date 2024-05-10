using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // Could implement using a String instead


    //private int currentLevelCount = 0;

    [SerializeField] private string scene;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            LoadNextScene();
        }    
    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene(scene);
        //SceneManager.LoadScene(currentLevelCount + 1);

        //currentLevelCount++;
    }




}
