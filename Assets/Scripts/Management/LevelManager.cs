using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Script handles the respawning of player at designated checkpoints per level

    //[SerializeField] private GameObject getCurrentScene;
    


    [SerializeField] private Transform checkpointLocation;
    [SerializeField] private Transform player;

    //private int currentPlayerLives;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //getCurrentScene = GameObject.FindWithTag("Level");
        //livesManager = GetComponent<LivesManager>();
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
        player.transform.position = checkpointLocation.transform.position;
    }
}
