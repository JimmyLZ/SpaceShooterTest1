using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogotime = 3.0f;

    private void Start()
    {
       
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        //Preload the game
        

        if (Time.time < minimumLogotime)
            loadTime = minimumLogotime;
        else
            loadTime = Time.time;


    }


    private void Update()
    {
        if (Time.time < minimumLogotime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        if (Time.time > minimumLogotime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogotime;
            if (fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("Menu");
            }

        }
    }
}

  


