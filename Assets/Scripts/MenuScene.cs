using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f; // One devide by three

    private void Start()
    {

        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

    }

    private void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }

    public void OnPlayClick()
    {
        Debug.Log("Play Clicked");
    }

    public void OnShopClick()
    {
        Debug.Log("Shop Clicked");
    }


}
