using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLevel : MonoBehaviour
{
    [SerializeField] private LivesManager livesManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (livesManager.currentLives == 0)
        {
            Debug.Log("Unloading level");
            DestroyLevel();
        }
    }


    private void DestroyLevel()
    {
        Debug.Log("Destroyed level");
        Destroy(gameObject);
    }
}
