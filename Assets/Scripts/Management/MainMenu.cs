using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float waitOnSecondsMenu;

    public bool isRestarting = false;


    // Start is called before the first frame update
    void Start()
    {
        if(isRestarting)
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeInHierarchy)
        {
            waitOnSecondsMenu -= Time.deltaTime;
        }

        if (waitOnSecondsMenu < 0)
        {
            gameOverScreen.SetActive(false);
        }

    }
}
