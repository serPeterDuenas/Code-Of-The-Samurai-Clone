using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.thisInstance.ChangeStage(0);
        LevelManager.thisInstance.PlayStageMusic();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Space)) 
        {
            GoNextScene();
        }

    }

    private void GoNextScene()
    {
        SceneManager.LoadScene(sceneName);
        LevelManager.thisInstance.ChangeStage(1);
        LevelManager.thisInstance.PlayStageMusic();
    }

}
