using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     // Script handles the respawning of player at designated checkpoints per level
    


    [SerializeField] private Transform checkpointLocation;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void RespawnPlayer()
    {
        Debug.Log("Respawning player");
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        player.transform.position = checkpointLocation.transform.position;
    }
}
