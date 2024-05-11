using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager thisInstance;

    // Start is called before the first frame update
    void Start()
    {
       
        DontDestroyOnLoad(gameObject);
        if (thisInstance == null)
        {
            thisInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
    }


    public void RespawnPlayer()
    {
        //currentPlayerLives = getLives;

        //Debug.Log("Respawning player");
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
