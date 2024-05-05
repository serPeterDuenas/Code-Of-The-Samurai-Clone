using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    //[SerializeField] private Scene[] scenes;
    private int currentLevelCount = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            LoadNextScene();
        }    
    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentLevelCount + 1);

        currentLevelCount++;
    }

}
