using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    private static DontDestroyUI thisInstance;
    public bool isLoadingMenu = false;

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
        if(isLoadingMenu)
        {
            Destroy(gameObject);
        }
        //Debug.Log(isLoadingMenu);
    }
}
